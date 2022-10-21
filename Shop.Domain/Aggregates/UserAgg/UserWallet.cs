﻿using Common.Domain;
using Shop.Domain.OrderAgg;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg;

public class UserWallet : BaseEntity
{
    public UserWallet()
    {

    }
    public UserWallet(int price, string description, bool isFinally, WalletType type)
    {
        if (price < 500)
            throw new InvalidDomainDataException();
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
        if (isFinally)
            FinallyDate = DateTime.Now;
    }

    public Guid UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType Type { get; private set; }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $" کد پیگیری : {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}

