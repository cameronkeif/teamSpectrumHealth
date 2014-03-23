//-----------------------------------------------------------------------
// <copyright file="IgnoredPendingShortageRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;

    public class IgnoredPendingShortageRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        private IgnoredPendingShortageDBContext db = new IgnoredPendingShortageDBContext();

        /// <summary>
        /// Gets all pending shortages ignored by the given username
        /// </summary>
        /// <param name="username">The user</param>
        /// <returns>All watch list items for the given username</returns>
        public IgnoredPendingShortage[] GetIgnoredPendingShortages(string username)
        {
            try
            {
                var ignoredPendingShortages = from ignoredPendingShortage in this.db.IgnoredPendingShortages
                                              select ignoredPendingShortage;

                ignoredPendingShortages = ignoredPendingShortages.Where(item => item.Username == username);

                return ignoredPendingShortages.ToArray();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Add an ignored pending shortages to the database
        /// </summary>
        /// <param name="item">The item to add to the user's watch list.</param>
        public void AddIgnoredPendingShortage(IgnoredPendingShortage item)
        {
            this.db.IgnoredPendingShortages.Add(item);
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                int i = 0;
                i++;
            }
        }

        /// <summary>
        /// Removes an ignored pending shortage from the Database
        /// </summary>
        /// <param name="username">The user</param>
        /// <param name="sourceUrl">The source URL of the pending shortage to be ignored</param>
        public void RemoveIgnoredPendingShortage(string username, string sourceUrl)
        {
            try
            {
                var existingItem = this.db.IgnoredPendingShortages.First(item => item.Username == username && item.SourceUrl == sourceUrl);
                this.db.IgnoredPendingShortages.Remove(existingItem);
                this.db.SaveChanges();
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}