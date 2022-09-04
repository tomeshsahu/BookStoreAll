using DatabaseLayer.FeedBackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel);
        public List<DisplayFeedback> GetAllFeedback(int bookId);
    }
}
