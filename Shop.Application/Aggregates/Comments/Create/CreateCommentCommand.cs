﻿using AngleSharp.Media.Dom;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Comments.Create;
public class CreateCommentCommand:IBaseCommand
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public string Text { get; set; }
}

//public record CreateCommentCommand(string Text, Guid UserId, Guid ProductId) : IBaseCommand;
