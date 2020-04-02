using System;
using System.Threading.Tasks;
using Abp.TestBase;
using datascienceanalytics.com.EntityFrameworkCore;
using datascienceanalytics.com.Tests.TestDatas;

namespace datascienceanalytics.com.Tests
{
    public class comTestBase : AbpIntegratedTestBase<comTestModule>
    {
        public comTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<comDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<comDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<comDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<comDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<comDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<comDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<comDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<comDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
