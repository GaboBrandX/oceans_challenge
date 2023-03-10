using System;
using System.Collections.Generic;
using System.Linq;

namespace Oceans.Exercise
{
    public class User
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user's chosen payment type
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// The user's subscriptions
        /// </summary>
        internal IEnumerable<Subscription> Subscriptions { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="subscriptions">The subscriptions the user has.</param>
        public User(IEnumerable<Subscription> subscriptions)
        {
            this.Subscriptions = subscriptions;
        }

        /// <summary>
        /// The number of expired subscriptions the user has
        /// </summary>
        public int ExpiredSubscriptions
        {
            get
            {
                var today = DateTime.Now;
                if (Subscriptions == null || !Subscriptions.Any())
                {
                    return 0;
                }

                return Subscriptions.Where(subscription => IsSubscriptionExpired(subscription, today)).Count();
            }
        }

        private static bool IsSubscriptionExpired(Subscription subscription, DateTime today)
        {
            var lastDayOfExpirationMonth = DateTime.DaysInMonth(subscription.ExpirationYear, subscription.ExpirationMonth);
            var expirationDate = new DateTime(subscription.ExpirationYear, subscription.ExpirationMonth, lastDayOfExpirationMonth, 23, 59, 59);
            return DateTime.Now > expirationDate;
        }

        /// <summary>
        /// Rewrite this method using discard for output variable
        /// </summary>
        public void UpdateUserName()
        {
            const string strForExercise = "1";

            if (int.TryParse(strForExercise, out int myOutputVariable))
            {
                Name = "Oceans Code Experts";
            }
        }

        /// <summary>
        /// Rewrite this method to return a tuple of Name, PaymentType and the local variable
        /// </summary>
        public (string name, PaymentType paymentType, bool codeExperts) UserInformation()
        {
            bool codeExperts = true;
            return (Name, PaymentType, codeExperts);
        }

        /// <summary>
        /// Update the local variables by deconstructing the tuple from UserInformation
        /// Follow the sugested logic to update the User Name
        /// </summary>
        public void UpdateUserInformation()
        {
            string nameFromTuple = string.Empty;
            bool codeExpertsFromTuple = false;

            //deconstruct the tuple
            var values = UserInformation();
            nameFromTuple = values.name;
            codeExpertsFromTuple = values.codeExperts;

            if (codeExpertsFromTuple)
            {
                Name = $"Recruiting {nameFromTuple}";
            }
        }
    }
}