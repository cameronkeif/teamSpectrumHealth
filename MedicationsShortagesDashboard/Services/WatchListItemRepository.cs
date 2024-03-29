﻿//-----------------------------------------------------------------------
// <copyright file="WatchListItemRepository.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Services
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using MedicationsShortagesDashboard.Models;
   
    /// <summary>
    /// Performs database queries to WATCHLIST_ITEM table
    /// </summary>
    public class WatchListItemRepository
    {
        /// <summary>
        /// Database context
        /// </summary>
        private WatchListItemDBContext db = new WatchListItemDBContext();

        /// <summary>
        /// Gets all watch list items for the given username
        /// </summary>
        /// <param name="username">The user</param>
        /// <returns>All watch list items for the given username</returns>
        public WatchListItem[] GetWatchListItems(string username)
        {
            try
            {
                var watchListItems = from watchListItem in this.db.Items
                            select watchListItem;

                watchListItems = watchListItems.Where(item => item.Username == username);

                return watchListItems.ToArray();
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Add an item to the database
        /// </summary>
        /// <param name="item">The item to add to the user's watch list.</param>
        public void AddWatchListItem(WatchListItem item)
        {
            this.db.Items.Add(item);
            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        /// <summary>
        /// Removes a watch list item
        /// </summary>
        /// <param name="username">The user</param>
        /// <param name="ndc">The National Drug Code of the drug they're taking off their watch list</param>
        public void RemoveWatchListItem(string username, string ndc)
        {
            try
            {
                var existingItem = this.db.Items.First(item => item.Username == username && item.Ndc == ndc);
                this.db.Items.Remove(existingItem);
                this.db.SaveChanges();
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Deletes an item from the watch list table
        /// </summary>
        /// <param name="username">the user's username</param>
        /// <param name="ndc">national drug code</param>
        public void DeleteWatchListItem(string username, string ndc)
        {
            var watchListITem = this.db.Items.First(i => i.Username == username && i.Ndc == ndc);
            try
            {
                this.db.Items.Remove(watchListITem);
                this.db.SaveChanges();
            }
            catch (InvalidOperationException)
            {
            }
            catch (DbUpdateException)
            {
            }
        }
    }
}