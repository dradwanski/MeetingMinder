﻿using Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User
{
    public record GetUserByMailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }

    }
}
