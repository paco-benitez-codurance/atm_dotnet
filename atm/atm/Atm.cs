﻿namespace atm;

public class Atm
{
    public Wallet WithDraw(int money)
    {
        var result = WithDrawAsList(money);
        return Wallet.Of(result.ToArray());
    }

    private List<Money> WithDrawAsList(int money)
    {
        if (money == 0) return new List<Money>();
        var head = TakeWithValue(money);
        var tail = WithDrawAsList(money - head.Value);
        tail.Add(head);
        return tail;
    }

    private static Money TakeWithValue(int money)
    {
        return Money.All().First(x => x.Value <= money);
    }

}