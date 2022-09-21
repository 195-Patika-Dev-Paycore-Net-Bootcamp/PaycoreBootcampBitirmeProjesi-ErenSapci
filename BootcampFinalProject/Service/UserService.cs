using AutoMapper;
using NHibernate;
using System;
using System.Collections.Generic;
using BC = BCrypt.Net.BCrypt;
using System.Linq;
using BootcampFinalProject.Base.Concrete;
using BootcampFinalProject.Models;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Base.Response;
using BootcampFinalProject.Entities.Repository;
using BootcampFinalProject.Authorization;

namespace BootcampFinalProject.Service
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        protected new readonly ISession session;
        protected new readonly IMapper mapper;
        protected new readonly IHibernateRepository<User> hibernateRepository;

        public UserService(ISession session, IMapper mapper) : base(session, mapper)
        {

            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<User>(session);
        }

        public override BaseResponse<IEnumerable<UserDto>> GetAll()
        {
            return base.GetAll();
        }

        public override BaseResponse<UserDto> GetById(int id)
        {
            return base.GetById(id);
        }

        public override BaseResponse<UserDto> Insert(UserDto insertResource)
        {
            return base.Insert(insertResource);
        }

        //This is the section where we get the registration information from the user.
        //In this section, we check whether the user's e-mail is correct or not. then we encrypt the password with the help of BCrypt.
        //We add the incoming user to our model.
        public virtual void Register(UserDto model)
        {
            var UserList = hibernateRepository.GetAll();
            
            // validate
            if (UserList.ToArray().Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            // hash password
            model.Password = BC.HashPassword(model.Password);

            // save user
            base.Insert(model);
        }

        public UserDto GetUserByEmail(string email)
        {

            return mapper.Map<UserDto>(hibernateRepository.Find(x => x.Email == email).First());
        }
    }
}
