using Model;
using Service;
using System;

namespace Controller
{
    public class FeedbackController
    {
        public string CreateFeedback(Feedback feedback)
        {
            try
            {
                feedbackService.CreateFeedback(feedback);
            } catch (InvalidGradeException e)
            {
                return e.Message;
            }
            catch (TooLongFieldException e)
            {
                return e.Message;
            }

            return "Successfully created new feedback for doctor " + feedback.Appointment.Doctor.Name;
        }

        public int GetFeedbacksByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public FeedbackService feedbackService = new FeedbackService();

    }
}