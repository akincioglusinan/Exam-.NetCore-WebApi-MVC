using System;
using System.Collections.Generic;
using System.Text;
using SinavProje.Entities.Concrete;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Business.Constants
{
    public static class Messages
    {
        public static string ExamAdded = "Sınav başarıyla eklendi.";
        public static string ExamUpdated = "Sınav başarıyla güncellendi.";
        public static string ExamDeleted = "Sınav silindi.";

        public static string ExamAddError = "Sınav eklenirken hata oluştu.";
        public static string ExamDeleteError = "Sınav silinirken hata oluştu.";

        public static string GetExamError = "Sınav getirilirken hata oluştu.";
        public static string GetExamsError = "Sınavlar getirilirken hata oluştu.";
        public static string ExamUpdateError = "Sınav güncellenirken hata oluştu";

        public static string GetQuestionsError = "Tüm sorular getirilirken hata oluştu.";
        public static string GetQuestionsByExamError = "Sınav soruları getirilirken hata oluştu.";
        public static string GetQuestionError = "Soru getirilirken hata oluştu.";
        public static string QuestionAddError = "Soru eklenirken hata oluştu.";
        public static string QuestionUpdateError = "Soru güncellenirken hata oluştu.";
        public static string QuestionDeleteError = "Soru silinirken hata oluştu.";

        public static string QuestionAdded = "Soru başarıyla eklendi.";
        public static string QuestionUpdated = "Soru başarıyla güncellendi.";
        public static string QuestionDeleted = "Soru başarıyla silindi.";
        public static string GetUsersError = "Üyeler getirilirken hata oluştu.";
        public static string GetUserError = "Üyeler getirilirken hata oluştu.";

        public static string UserAddError = "Üye eklenirken hata oluştu.";
        public static string UserAdded = "Üye başarıyla eklendi.";
        public static string UserUpdateError = "Üye güncellenirken hata oluştu.";

        public static string UserUpdated = "Üye başarıyla güncellendi.";
        public static string UserDeleteError = "Üye silinirken hata oluştu.";
        public static string UserDeleted = "Üye başarıyla silindi.";

        public static string UserNotFound = "Bu email adresi ile kayıtlı bir kullanıcı bulunamadı!";
        public static string PasswordError = "Parola hatalı!";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Email kullanılıyor!";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}