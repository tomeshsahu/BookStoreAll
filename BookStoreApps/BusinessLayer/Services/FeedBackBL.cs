using BusinessLayer.Interface;
using DatabaseLayer.FeedBackModel;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{

    public class FeedBackBL : IFeedBackBL
    {
        IFeedbackRL feedBackRL;
        public FeedBackBL(IFeedbackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }
        public string AddFeedback(int UserId, FeedBackPostModel feedbackPostModel)
        {
            try
            {
                return this.feedBackRL.AddFeedback(UserId, feedbackPostModel);
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        public List<DisplayFeedback> GetAllFeedback(int bookId)
        {
            try
            {
                return this.feedBackRL.GetAllFeedback(bookId);
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
    }
}
