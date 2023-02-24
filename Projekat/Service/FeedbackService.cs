using Controller;
using Model;
using Repository;
using System;

namespace Service
{
    public class FeedbackService
    {
        public void CreateFeedback(Feedback feedback)
        {
            ValidateFeedbackInformation(feedback);
            feedbackRepository.Create(feedback);
        }

        private void ValidateFeedbackInformation(Feedback feedback)
        {
            if (!(UtilityService.IsInGradeRange(feedback.Grade))) throw new InvalidGradeException("You entered invalid value for grade.");
            if (UtilityService.IsCommentTooLong(feedback.Comment)) throw new TooLongFieldException("You entered too long input in field");
        }

        public int GetFeedbacksByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public FeedbackRepository feedbackRepository = new FeedbackRepository();

    }
}