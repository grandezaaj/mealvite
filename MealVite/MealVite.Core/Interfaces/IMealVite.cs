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
        void Reserve(int mealviteId, int userId);
        void CancelReservation(int mealviteId, int userId);
        void CancelMealvite(int mealviteId, int userId, string reason);
        void MoveMealvite(int mealviteId, int userId, DateTime date);
        void RateAndComment(int mealviteId, int userId, int rate, string comment);
        double CalculateTotal(int mealviteId);
        int GetAtendeesCount(int mealviteId);
    }
}
