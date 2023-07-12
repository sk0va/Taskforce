namespace Taskforce.UnitTests;

public class Tests
{
    public interface ISetPropertyCalls<TSource>
    {
        public ISetPropertyCalls<TSource> SetProperty<TProperty>(
            Func<TSource, TProperty> propertyExpression,
            Func<TSource, TProperty> valueExpression);
        public ISetPropertyCalls<TSource> SetProperty<TProperty>(
            Func<TSource, TProperty> propertyExpression,
            TProperty valueExpression);
    }

    public class Sa1<TProperty, TSource>
    {
        public Type tp1;
        public Type tp0;
        public Type[] methodParameters;


        public void Set()
        {
            var tp2 = Type.MakeGenericMethodParameter(0);
            // tp2 = typeof(string);

            var tg = typeof(Func<,>);
            tp0 = tg.MakeGenericType(typeof(DateTime), tp2);

            methodParameters = new[] { tp0, tp2 };
            Console.WriteLine(tp0.ToString());
            Console.WriteLine(tp2.ToString());

            var miSetProperty =  typeof(ISetPropertyCalls<TSource>)
                .GetMethod(
                    nameof(ISetPropertyCalls<TSource>.SetProperty),
                    1,
                    methodParameters);

var mm =                   miSetProperty.MakeGenericMethod(typeof(string));
            Console.WriteLine(mm.ToString());

            Assert.True(miSetProperty != null);
        }
    }

    [Fact]
    public void TestMethod1()
    {
        var sa1 = new Sa1<string, DateTime>();
        sa1.Set();

        var mi = typeof(ISetPropertyCalls<DateTime>).GetMethods();
    }

}
