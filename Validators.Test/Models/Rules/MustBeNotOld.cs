﻿using Validators.Types;

namespace Validators.Test.Models.Rules
{
    public class MustBeNotOld : ICheckRule
    {
        private readonly Car car;

        public MustBeNotOld(Car car)
        {
            this.car = car;
        }
        public CheckRuleState State { get; set; }

        public Task Run()
        {
            return Task.Run(() =>
            {
                State = CheckRuleState.Valid;
                if (car.Age > 10)
                {
                    State = CheckRuleState.InValid;
                }

                if (car.FourWheelDrive && car.Age > 5)
                {
                    State = CheckRuleState.InValid;
                }
            });
            
        }
    }
}
