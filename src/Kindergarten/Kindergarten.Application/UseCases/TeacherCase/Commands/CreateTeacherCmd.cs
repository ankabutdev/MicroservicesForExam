﻿using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Commands;

public class CreateTeacherCmd : IRequest<bool>
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

}
