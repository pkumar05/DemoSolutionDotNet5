using AutoMapper;
using DM.ApplicationServices.Helper;
using DS.ApplicationServices.Command;
//using DS.ApplicationServices.Command;
using DS.Domain.DTO;
using DS.Domain.Entities;
using DS.Domain.Interfaces;
using DS.ServicesInterfaces;
//using DS.ApplicationServices.Helper;
using PK.BuildingBlocks.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DS.ApplicationServices
{
    public class MasterService : IMasterService
    {
        readonly IDepartmentsRequestRepos _departmentsRequestRepos;
        readonly IEmployeeRequestRepos _employeeRequestRepos;
        // readonly IEmployeeProfileRequestRepos _employeeProfileRequestRepos;
        readonly IProfileRequestRepos _profileRequestRepos;

        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public MasterService(
           IDepartmentsRequestRepos departmentsRequestRepos,
        IEmployeeRequestRepos employeeRequestRepos,
        // IEmployeeProfileRequestRepos employeeProfileRequestRepos,
        IProfileRequestRepos profileRequestRepos,
        IMapper mapper,
         IUnitOfWork unitOfWork
            )
        {
            _departmentsRequestRepos = departmentsRequestRepos;
            _employeeRequestRepos = employeeRequestRepos;
            // _employeeProfileRequestRepos = employeeProfileRequestRepos;
            _profileRequestRepos = profileRequestRepos;

            _mapper = mapper;
            _unitOfWork = unitOfWork;


        }

        readonly ServiceResponse _response = new ServiceResponse();

        /// <summary>
        /// Method added to create Department.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> AddDepartment(AddDepartmentRequest request, string createdBy)
        {
            #region These checks needs to be moved from here

            if (String.IsNullOrEmpty(createdBy))
                createdBy = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.Name))
                request.Name = request.Name.TitleCase();
            if (!string.IsNullOrEmpty(request.Code))
                request.Code = request.Code.ToUpper();

            #endregion

            // To check if department already exist.
            var checkDepartment = _departmentsRequestRepos.Get(x => x.Active && x.Name == request.Name);
            if (checkDepartment == null)
            {
                var department = await CreateDepartmentCommand.CreateDepartment(request, createdBy);
                _departmentsRequestRepos.Add(department);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.RecordAddedSuccessfully;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.AlreadyExist;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }
        /// <summary>
        /// Method added to get department list.
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> GetDepartmentList(string searchField, string userName)
        {
            var searchDepartment = _departmentsRequestRepos.GetAll(x => x.Active)
                .Where(a => a.Name.Contains(searchField) || string.IsNullOrEmpty(searchField)).OrderBy(b => b.Name).ToList();

            if (searchDepartment == null)
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = true;
            }
            else
            {
                _response.data = searchDepartment;
                _response.msg = CommonConstants.RecordsRetrievedSuccessfully;
                _response.success = true;

            }
            return await Task.Run(() => _response);

        }
        /// <summary>
        /// Method added to update the department.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> UpdateDepartment(UpdateDepartmentRequest request, string modifiedUser)
        {
            #region These check needs to be moved from here
            if (string.IsNullOrEmpty(modifiedUser))
                modifiedUser = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.Name))
                request.Name = request.Name.TitleCase();
            if (!string.IsNullOrEmpty(request.Code))
                request.Code = request.Code.ToUpper();
            #endregion

            // To check if department already exist.
            var checkDepartment = _departmentsRequestRepos.Get(x => x.Active && x.Id == request.Id);
            if (checkDepartment != null)
            {
                var department = await UpdateDepartmentCommand.UpdateDepartment(checkDepartment, request, modifiedUser);
                _departmentsRequestRepos.AddOrUpdate(department);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.SuccessfullyUpdated;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> AddProfile(AddProfileRequest request, string createdBy)
        {
            #region These checks needs to be moved from here
            if (String.IsNullOrEmpty(createdBy))
                createdBy = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.Name))
                request.Name = request.Name.TitleCase();
            if (!string.IsNullOrEmpty(request.Code))
                request.Code = request.Code.ToUpper();
            #endregion

            // To check if department already exist.
            var checkProfile = _profileRequestRepos.Get(x => x.Active && x.Name == request.Name);
            if (checkProfile == null)
            {
                var createProfile = await CreateProfileCommand.CreateProfile(request, createdBy);
                _profileRequestRepos.Add(createProfile);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.RecordAddedSuccessfully;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.AlreadyExist;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }
        /// <summary>
        /// Method added to get list of Profile
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> GetProfileList(string searchField, string userName)
        {
            var searchProfile = _profileRequestRepos.GetAll(x => x.Active)
                .Where(a => a.Name.Contains(searchField) || string.IsNullOrEmpty(searchField)).OrderBy(b => b.Name).ToList();

            if (searchProfile == null)
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = true;
            }
            else
            {
                _response.data = searchProfile;
                _response.msg = CommonConstants.RecordsRetrievedSuccessfully;
                _response.success = true;

            }
            return await Task.Run(() => _response);
        }


        /// <summary>
        /// Method added to update profile
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> UpdateProfile(UpdateProfileRequest request, string userName)
        {

            #region These checks needs to be moved from here
            if (string.IsNullOrEmpty(userName))
                userName = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.Name))
                request.Name = request.Name.TitleCase();
            if (!string.IsNullOrEmpty(request.Code))
                request.Code = request.Code.ToUpper();
            #endregion

            // To check if profile already exist.
            var checkProfile = _profileRequestRepos.Get(x => x.Active && x.Id == request.Id);
            if (checkProfile != null)
            {
                var profile = await UpdateProfileCommand.UpdateProfile(checkProfile, request, userName);
                _profileRequestRepos.AddOrUpdate(profile);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.SuccessfullyUpdated;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cretedBy"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> AddEmployee(AddEmployeeRequest request, string cretedBy)
        {

            #region These checks need to be moved from here
            if (string.IsNullOrEmpty(cretedBy))
                cretedBy = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.FirstName))
                request.FirstName = request.FirstName.TitleCase();
            if (!string.IsNullOrEmpty(request.MiddleName))
                request.MiddleName = request.MiddleName.TitleCase();
            if (!string.IsNullOrEmpty(request.LastName))
                request.LastName = request.LastName.TitleCase();
            if (!string.IsNullOrEmpty(request.Email))
                request.Email = request.Email.UpperCase();
            #endregion

            // To check if employee already exist.
            var checkEmployee = _employeeRequestRepos.Get(x => x.Active && x.FirstName == request.FirstName && x.LastName == request.LastName & x.Email == request.Email);
            if (checkEmployee == null)
            {
                var employee = await CreateEmployeeCommand.CreateEmployee(request, cretedBy);
                _employeeRequestRepos.Add(employee);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.RecordAddedSuccessfully;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.AlreadyExist;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> GetEmployeeList(string searchField, string userName)
        {
            var searchEmployee = _employeeRequestRepos.GetAll(x => x.Active)
                .Where(a => a.FirstName.Contains(searchField)
                    // ||a.MiddleName.Contains(searchField)
                    || a.LastName.Contains(searchField)
                    || a.EmployeeID.ToString().Contains(searchField)
                    //||a.Email.Contains(searchField)
                    //||a.Phone.Contains(searchField)
                    || string.IsNullOrEmpty(searchField)
                    ).OrderBy(b => b.EmployeeID).ToList();

            if (searchEmployee == null)
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = true;
            }
            else
            {
                _response.data = searchEmployee;
                _response.msg = CommonConstants.RecordsRetrievedSuccessfully;
                _response.success = true;

            }
            return await Task.Run(() => _response);
        }

        /// <summary>
        /// Method added to update employee
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse> UpdateEmployee(UpdateEmpoyeeRequest request, string userName)
        {
            #region These checks needs to move later from here
            if (string.IsNullOrEmpty(userName))
                userName = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.FirstName))
                request.FirstName = request.FirstName.TitleCase();
            if (!string.IsNullOrEmpty(request.MiddleName))
                request.MiddleName = request.MiddleName.TitleCase();
            if (!string.IsNullOrEmpty(request.LastName))
                request.LastName = request.LastName.TitleCase();
            if (!string.IsNullOrEmpty(request.Email))
                request.Email = request.Email.UpperCase();
            if (!string.IsNullOrEmpty(request.Phone))
                request.Phone = request.Phone.UpperCase();
            if (!string.IsNullOrEmpty(request.HomeAddress))
                request.HomeAddress = request.HomeAddress.UpperCase();
            #endregion

            // To check if Employee already exist.
            var checkEmployee = _employeeRequestRepos.Get(x => x.Active && x.Id == request.Id);
            if (checkEmployee != null)
            {
                var employee = await UpdateEmployeeCommand.UpdateEmployee(checkEmployee, request, userName);
                _employeeRequestRepos.AddOrUpdate(employee);

                await _unitOfWork.CommitAsync();
                _response.msg = CommonConstants.SuccessfullyUpdated;
                _response.success = true;

            }
            else
            {
                _response.msg = CommonConstants.NoDataAvailable;
                _response.success = false;
            }

            return await Task.Run(() => _response);
        }
    }
}
