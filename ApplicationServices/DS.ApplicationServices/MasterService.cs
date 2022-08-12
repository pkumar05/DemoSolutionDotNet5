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
        //readonly IEmployeeRequestRepos _employeeRequestRepos;
        //readonly IEmployeeProfileRequestRepos _employeeProfileRequestRepos;
        //readonly IProfileRequestRepos _profileRequestRepos;

        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public MasterService(
           IDepartmentsRequestRepos departmentsRequestRepos,
        //IEmployeeRequestRepos employeeRequestRepos,
        //IEmployeeProfileRequestRepos employeeProfileRequestRepos,
        //IProfileRequestRepos profileRequestRepos,
        IMapper mapper,
         IUnitOfWork unitOfWork
            )
        {
            _departmentsRequestRepos = departmentsRequestRepos;
            //_employeeRequestRepos = employeeRequestRepos;
            //_employeeProfileRequestRepos = employeeProfileRequestRepos;
            //_profileRequestRepos = profileRequestRepos;

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
            #region Temporary Check as it needs to move into Fluent Validation section will defined separately under Domain Project --> Validators
            //if (string.IsNullOrEmpty(request.Name))
            //    throw new ArgumentException(CommonConstants.MissingRequiredInputValues);
            //else
            //    request.Name = request.Name.TitleCase();

            //if (string.IsNullOrEmpty(createdBy))
            //    createdBy = "SYSTEM-ADMIN";
            
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
            var searchDepartment = _departmentsRequestRepos.GetAll(x=>x.Active)
                .Where(a=>a.Name==searchField || string.IsNullOrEmpty(searchField)).OrderBy(b=>b.Name).ToList();

            if (searchDepartment==null)
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
            if (string.IsNullOrEmpty(modifiedUser))
                modifiedUser = "SYSTEM-ADMIN";
            if (!string.IsNullOrEmpty(request.Name))
                request.Name = request.Name.TitleCase();
            if (!string.IsNullOrEmpty(request.Code))
                request.Code = request.Code.ToUpper();

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
        public Task<ServiceResponse> AddProfile()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ServiceResponse> GetProfileList(string searchField, string userName)
        {
            throw new NotImplementedException();
        }

    }
}
