using CareerHub.Client.API.Students.Appointments;
using CareerHub.Client.API.Students.Education;
using CareerHub.Client.API.Students.Events;
using CareerHub.Client.API.Students.Experiences;
using CareerHub.Client.API.Students.Jobs;
using CareerHub.Client.API.Students.News;
using CareerHub.Client.API.Students.Questions;
using CareerHub.Client.API.Students.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students {
    public sealed class StudentsApiFactory {
        private readonly APIInfo info = null;
        private readonly string accessToken = null;

        public StudentsApiFactory(APIInfo info, string accessToken) {
            this.info = info;
            this.accessToken = accessToken;
        }

        public IAppointmentBookingsApi GetAppointmentBookingsApi() {
            RequireComponent("Appointments");
            return new AppointmentBookingsApi(info.BaseUrl, accessToken);
        }

        public IEducationApi GetEducationApi() {
            return new EducationApi(info.BaseUrl, accessToken);
        }
        
        public IEventsApi GetEventsApi() {
            return new EventsApi(info.BaseUrl, accessToken);
        }

        public IEventBookingsApi GetEventBookingsApi() {
            return new EventBookingsApi(info.BaseUrl, accessToken);
        }

        public IExperiencesApi GetExperiencesApi() {
            return new ExperiencesApi(info.BaseUrl, accessToken);
        }

        public IJobsApi GetJobsApi() {
            return new JobsApi(info.BaseUrl, accessToken);
        }

        public INewsApi GetNewsApi() {
            return new NewsApi(info.BaseUrl, accessToken);
        }

        public IQuestionsApi GetQuestionsApi() {
            RequireComponent("Questions");
            return new QuestionsApi(info.BaseUrl, accessToken);
        }

        public IQuestionResponsesApi GetQuestionResponsesApi() {
            RequireComponent("Questions");
            return new QuestionResponsesApi(info.BaseUrl, accessToken);
        }

        public IResourcesApi GetResourcesApi() {
            return new ResourcesApi(info.BaseUrl, accessToken);
        }

        private void RequireComponent(string name) {
            if (!info.SupportedComponents.Contains(name, StringComparer.OrdinalIgnoreCase)) {
                throw new NotSupportedException("The component " + name + " is not supported by " + info.BaseUrl);
            }
        }
    }
}
