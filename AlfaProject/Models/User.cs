using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;

namespace AlfaProject.Models
{
    public record User(string Id, bool IsDeleted, FullNameValue FullName, string Login, DateTimeConvertibleValue CreatedAt, DateTimeConvertibleValue UpdatedAt)
    {
        public User(FullNameValue fullName, string login) : this(Guid.NewGuid().ToString(), false, fullName, login, DateTimeConvertibleValue.GetForNow, DateTimeConvertibleValue.GetForNow) { }

        public User ContinueWithNewFullNameAndLogin(FullNameValue fullName, string login)
        {
            return this with { FullName = fullName, Login = login, UpdatedAt = DateTimeConvertibleValue.GetForNow };
        }
        public User ContinueWithIsDeleted(bool isDeleted)
        {
            return this with {IsDeleted = isDeleted};
        }
    }

    public record DateTimeConvertibleValue(DateTime Value)
    {
        public long ValueInt => Value.Ticks;
        public DateTimeConvertibleValue(long value) : this(new DateTime(value)) { }
        public static DateTimeConvertibleValue GetForNow => new DateTimeConvertibleValue(DateTime.Now);
    }

    public record FullNameValue(string FirstName, string LastName, string MiddleName);
}