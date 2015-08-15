using MealVite.Core.Base;
using MealVite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealVite.Core.Interfaces
{
    public interface IMealVite : IRepository<Mealvite>
    {
        void Reserve(MealViteDetail mvd);
        void CancelReservation(int mealviteId, int userId);
        void CancelMealvite(int mealviteId, int userId);
        double MealviteTotal(int mealviteId);
        int AtendeesCount(int mealviteId);
        void MoveMealvite(int mealviteId, DateTime date, string reason);
        void RateAndComment(int mealviteId, double rate, string comment);
        void ChangeStatus(int mealviteId, string status);
        void PostMealvite(int userId, string title, double price, string location, string description, DateTime date, int atendeeCount);
    }
}
