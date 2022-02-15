using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi.";
        public static string Deleted = "Silindi.";
        public static string Updated = "Güncellendi.";
        public static string Listed = "Listelendi.";
        public static string Get = "Getirildi.";
        public static string SameNameExist = "Aynısı mevcut";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Hatalı şifre";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string AlreadyExists="Kullanıcı zaten var ";
        public static string UserRegistered="Kayıt olundu";
        public static string AccesTokenCreated="Access token başarıyla oluşturuldu";
    }
}
