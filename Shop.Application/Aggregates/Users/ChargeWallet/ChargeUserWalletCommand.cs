﻿using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Aggregates.Users.ChargeWallet;
public class ChargeUserWalletCommand:IBaseCommand
{
    public ChargeUserWalletCommand(Guid userId, int price, string description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }

    public Guid UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }
}



