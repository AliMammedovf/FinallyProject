using AutoMapper;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.Exceptions;
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

	public async Task AddAsyncReservation(ReservationCreateDTO reservationCreateDTO)
    {

        Reservation reserv = _mapper.Map<Reservation>(reservationCreateDTO);



        await  _reservationRepository.AddAsync(reserv);
        await  _reservationRepository.CommitAsync();


        
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
