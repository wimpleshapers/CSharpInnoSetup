
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class TasksExpressionToStringConverterTests
    {
        [Fact]
        public void TestConversion()
        {
            var tasks = new
            {
                Task1 = TaskFactory.CreateParent(
                    builder => builder.Build(),
                    new
                    {
                        Task2 = TaskFactory.CreateParent(
                            builder => builder.Build(),
                            new
                            {
                                Task3 = TaskFactory.CreateLeaf().Build()
                            })
                    }),
                Task4 = TaskFactory.CreateLeaf().Build()
            };

            TestConversionInternal("Task1", () => new [] { tasks.Task1 });
            TestConversionInternal("Task1 Task1\\Task2", () => new ITask[] { tasks.Task1, tasks.Task1.Children.Task2 });
            TestConversionInternal("Task1 Task1\\Task2 Task1\\Task2\\Task3", () => new ITask[] { tasks.Task1, tasks.Task1.Children.Task2, tasks.Task1.Children.Task2.Children.Task3 });
            TestConversionInternal("Task1 Task4", () => new ITask[] { tasks.Task1, tasks.Task4 });
        }

        [Fact]
        public void TestEmptyConversion()
        {
            TestConversionInternal("", () => new ITask[] { });
        }

        private void TestConversionInternal(string expected, Expression<Func<ITask[]>> expression)
        {
            var converter = new TasksExpressionToStringConverter();
            Assert.Equal(expected, converter.ConvertTo(expression, typeof(string)) as string);
        }
    }
}
