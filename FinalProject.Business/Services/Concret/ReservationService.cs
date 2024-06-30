using AutoMapper;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinalProject.Business.Services.Concret;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;
    private readonly ITableService _tableService;

	public ReservationService(IReservationRepository reservationRepository, IMapper mapper, ITableService tableService)
	{
		_reservationRepository = reservationRepository;
		_mapper = mapper;
		_tableService = tableService;
	}

	public async Task<bool> AddAsyncReservation(ReservationCreateDTO reservationCreateDTO, ModelStateDictionary ModelState, dynamic ViewBag)
    {

        if (!ModelState.IsValid)
            return false;


        var isExistReservation = await _tableService.IsExistAsync(x => !x.Reservations.Any(r => r.StartDate <= reservationCreateDTO.StartDate && r.EndDate >= reservationCreateDTO.EndDate));

        if (isExistReservation)
        {
            ModelState.AddModelError("", "Hemin masa doludur");
            return false;
        }



        if (reservationCreateDTO.StartDate < DateTime.Now)
        {
            ModelState.AddModelError("StartDate", "Kecmis tarix sece bilmezsen");

            return false;
        }

        if (reservationCreateDTO.EndDate < reservationCreateDTO.StartDate)
        {
            ModelState.AddModelError("StartDate", "Vaxti duzgun teyin edin!");
            return false;
        }


        Reservation reservation= _mapper.Map<Reservation>(reservationCreateDTO);

        await  _reservationRepository.AddAsync(reservation);
        await  _reservationRepository.CommitAsync();


        return true;
    }

    public List<ReservationGetDTO> GetAllReservations(Func<Reservation, bool>? func = null)
    {
       var reservation=  _reservationRepository.GetAll(func,"Table");

        List<ReservationGetDTO> reservationGetDTOs = _mapper.Map<List<ReservationGetDTO>>(reservation);

        return reservationGetDTOs;
    }

    public ReservationGetDTO GetReservation(Func<Reservation, bool>? func = null)
    {
        var reservation = _reservationRepository.Get(func, "Table");

        ReservationGetDTO reservationGetDTO= _mapper.Map<ReservationGetDTO>(reservation);

        return reservationGetDTO;
    }
}
