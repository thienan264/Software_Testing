using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using OrganizationApp.DAL;
using OrganizationApp.Exceptions;
using OrganizationApp.Models;

namespace OrganizationApp.BLL
{
    public class OrganizationService
    {
        private readonly OrganizationRepository _repo =
            new OrganizationRepository();

        public Dictionary<string, string> Validate(Organization o)
        {
            var err = new Dictionary<string, string>();

            // OrgName
            if (string.IsNullOrWhiteSpace(o.OrgName))
            {
                err["OrgName"] = "Không được để trống";
            }
            else if (o.OrgName.Length < 3 || o.OrgName.Length > 255)
            {
                err["OrgName"] = "Độ dài từ 3 đến 255 ký tự";
            }

            if (!string.IsNullOrWhiteSpace(o.Email))
            {
                try
                {
                    new MailAddress(o.Email);
                }
                catch
                {
                    err["Email"] = "Email sai định dạng";
                }
            }


            if (!string.IsNullOrWhiteSpace(o.Phone))
            {
                if (o.Phone.Any(x => !char.IsDigit(x)))
                {
                    err["Phone"] = "Chỉ được nhập số";
                }
                else if (o.Phone.Length < 9 || o.Phone.Length > 12)
                {
                    err["Phone"] = "Độ dài từ 9 đến 12 ký tự";
                }
            }

            return err;
        }
        public int Save(Organization o)
        {
            var errors = Validate(o);
            if (errors.Count > 0)
                throw new ValidationException(errors);

            if (_repo.ExistsByName(o.OrgName))
                throw new BusinessException("Organization Name already exists");

            return _repo.Insert(o);
        }
    }
}