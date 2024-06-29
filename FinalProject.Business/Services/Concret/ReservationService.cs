using AutoMapper;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task AddAsyncReservation(ReservationCreateDTO reservationCreateDTO)
    {
        Reservation reservation= _mapper.Map<Reservation>(reservationCreateDTO);

        await  _reservationRepository.AddAsync(reservation);
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
