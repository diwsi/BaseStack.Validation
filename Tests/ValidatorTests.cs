using Validators.Handlers;
using Validators.Test.Models;
using Validators.Test.Models.Rules;
using Validators.Types;

namespace Validators.Test
{
    [TestClass]
    public class ValidatorTests
    {
         
        [TestMethod]
        public async Task Parallel_Handler_Must_Be_Not_Valid()
        {
            // Arrange
            var handler = new ParallelHandler();
            var car = new Car()
            {
                Age = 3,
                FourWheelDrive = true,
                Price = 300,
                Color = "White"
            };

            var checkList = new CheckList(handler)
            {
                Rules = new List<ICheckRule>()
                {
                    new MustBeCheap(car),
                    new MustHaveNiceColor(car),
                    new MustBeNotOld(car)

                }
            };

            //Act
            await checkList.Run();

            //Assert
            Assert.IsTrue(!checkList.Valid);
            Assert.IsTrue(checkList.Rules.All(d=>d.State!=CheckRuleState.NotValidated));
        }

        [TestMethod]
        public async Task Parallel_Handler_Must_Be_Valid()
        {
            // Arrange
            var handler = new ParallelHandler();
            var car = new Car()
            {
                Age = 3,
                FourWheelDrive = true,
                Price = 300,
                Color = "White"
            };
           
            var checkList = new CheckList(handler)
            {
                Rules = new List<ICheckRule>()
                {
                    // new MustHaveNiceColor(car),
                    new MustBeCheap(car),                    
                    new MustBeNotOld(car)
                }
            };

            //Act
            await checkList.Run();

            //Assert
            Assert.IsTrue( checkList.Valid);
            Assert.IsTrue(checkList.Rules.All(d => d.State != CheckRuleState.NotValidated));
        }
    }
}