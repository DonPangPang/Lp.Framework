using Lp.Framework.Shared.Extensions;
using Lp.Framework.Shared.Base;
using Lp.Framework.Shared.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Lp.Framework.Test.Shared
{
    public class EntityTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public EntityTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            //var types = Assembly.GetExecutingAssembly().GetTypes().AsEnumerable();
            var types = (typeof(ITestBase<>)).Assembly.GetTypes().AsEnumerable();
            _testOutputHelper.WriteLine(types.Count().ToString());
            var entityTypes = types.Where(t => !t.IsAbstract && t.GetInterface("ITestBase`1") is not null);

            foreach (var type in entityTypes)
            {
                _testOutputHelper.WriteLine(type.Name);
            }

            _testOutputHelper.WriteLine("11111111111");
            Console.WriteLine("22222222222");
        }

        [Fact]
        public void Test2()
        {
            IApplicationBuilder app = null!;
            app.UseIdCreator<Guid>(() => Guid.NewGuid());

            User user = new();
            user.Create();

            _testOutputHelper.WriteLine(user.Id.ToString());
        }

        [Fact]
        public void Test3()
        {
            IServiceCollection services = null!;
            services.UseIdCreator(() =>
            {
                return $"Id:{DateTime.Now.ToShortDateString()}{Guid.NewGuid()}";
            });

            TestEntity test = new();
            test.Create();

            _testOutputHelper.WriteLine(test.Id.ToString());
        }

        private class TestEntity : EntityBase<string>
        {
        }
    }

    internal interface ITestBase<T>
    {
        public T Id { get; set; }
    }

    internal class TestEntity : ITestBase<Guid>
    {
        public Guid Id { get; set; }
    }
}