using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using IStockRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controller
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenInterface _token;

        private readonly SignInManager<AppUser> _signin;

        public AccountController(UserManager<AppUser> userManager, TokenInterface tokenInterface, SignInManager<AppUser> signIn){
            this._userManager = userManager;
            this._token = tokenInterface;
            this._signin = signIn;
        }

        [HttpPost]

        public async Task<IActionResult> CreateAccount([FromBody] UserDTO userDTO){
            try{
                if(!ModelState.IsValid){
                    return BadRequest();
                }

                var appuser = new AppUser{
                    UserName = userDTO.UserName,
                    Email = userDTO.EmailAddress
                };

                var createdUser = await _userManager.CreateAsync(appuser, userDTO.Password);

                if(createdUser.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(appuser, "User");

                    if(roleResult.Succeeded){
                        return Ok(new TokenDTO{
                            UserName = appuser.UserName,
                            Email = appuser.Email,
                            Token = _token.createToken(appuser)
                        });
                    }

                    else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }

                else{
                    return StatusCode(500, createdUser.Errors);
                }
            }

            catch(Exception e){
                 return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login){
             if(!ModelState.IsValid) return BadRequest();

             var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName==login.UserName);

             if(user==null) return BadRequest("Invalid user");

             var result = await _signin.CheckPasswordSignInAsync(user, login.Password, false);

             if(result.Succeeded){
                 return Ok(new TokenDTO{
                     UserName = user.UserName,
                     Email = user.Email,
                     Token = _token.createToken(user)
                 });
             }

             else{
                return BadRequest("Invalid email or password");
             }
                
             }
        }
    }
