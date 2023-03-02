using Validators.Types;

namespace Validators.Test.Models.Rules
{
    public class MustHaveNiceColor : ICheckRule
    {
        private readonly Car car;

        public MustHaveNiceColor(Car car)
        {
            this.car = car;
        }
        public CheckRuleState State { get; set; }

        public Task Run()
        {
            return Task.Run(() =>
            {
                switch (car.Color)
                {
                    case "Red":
                    case "Blue":
                    case "Black":
                        State = CheckRuleState.Valid;
                        break;
                    default:
                        State = CheckRuleState.InValid;
                        break;
                }
            });
        }
    }
}
