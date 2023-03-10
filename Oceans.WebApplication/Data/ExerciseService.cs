using Oceans.Exercise;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oceans.WebApplication.Data
{
    public class ExerciseService
    {
        public Task<int> GetExpectedNumberOfExpiredSubscriptions()
        {
            // Add here your expected number of expired subscriptions
            return Task.FromResult(3);
        }

        public Task<int> GetNumberExpiredSubscriptionsAsync()
        {
            // Configure a set of subscriptions
            // Example: 3 subscriptions expired last year previous month
            var date = DateTime.Now.AddYears(-1).AddMonths(-1);
            var subscriptions = new List<Subscription>()
            {
                new Subscription(date.Month, date.Year) { Name = "Netflix" },
                new Subscription(date.Month, date.Year) { Name = "Amazon Prime" }
            };


            var user = new User(subscriptions)
            {
                Name = "Mike Mora",
                PaymentType = PaymentType.AmericanExpress
            };

            // Return the number of expired subscriptions
            return Task.FromResult(user.ExpiredSubscriptions);
        }
    }
}
