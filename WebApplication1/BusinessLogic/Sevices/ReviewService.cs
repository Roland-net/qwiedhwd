using BusinessLogic.Interface;
using DataAccess.Models;
using System;
using DataAccess.Wrapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Sevices
{
    internal class ReviewService : IReviewService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public ReviewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Review>> GetAll()
        {
            return _repositoryWrapper.Review.FindAll().ToListAsync();
        }
        public Task<Review> GetById(int id)
        {
            var review = _repositoryWrapper.Review
                .FindByCondition(x => x.ReviewId == id).First();
            return Task.FromResult(review);
        }
        public Task Create(Review model)
        {
            _repositoryWrapper.Review.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Review model)
        {
            _repositoryWrapper.Review.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Review
                .FindByCondition(x => x.UserId == id).First();

            _repositoryWrapper.Review.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
