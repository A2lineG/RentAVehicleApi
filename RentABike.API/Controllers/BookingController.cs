using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Booking")]
    [AllowAnonymous]
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<BookingDTO> GetBookingList()
        {
            BookingManager bookingManager = new BookingManager();

            var booking = bookingManager.GetBookingList();

            return booking;
        }

        [HttpGet]
        [Route("ListByVehicle")]
        public List<BookingDTO> GetBookingListByVehicle(Guid vehicleId)
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(User.Identity.Name);

            BookingManager bookingManager = new BookingManager();

            var booking = bookingManager.GetBookingListByVehicleOrClient(vehicleId, client.Id);

            return booking;
        }

        [HttpGet]
        [Route("ListByClient")]
        public List<BookingDTO> GetBookingByClient(Guid clientId)
        {
            BookingManager bookingManager = new BookingManager();

            var booking = bookingManager.GetBookingByClient(clientId);

            return booking;
        }

        [HttpGet]
        [Route("ListByLoggedUser")]
        public List<BookingDTO> GetBookingByLoggedUser()
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(User.Identity.Name);

            BookingManager bookingManager = new BookingManager();

            var booking = bookingManager.GetBookingByClient(client.Id);

            return booking;
        }

        [HttpGet]
        [Route("DetailBooking")]
        public BookingDTO GetBookingDetailByClient(Guid bookingId)
        {
            BookingManager bookingManager = new BookingManager();

            var bookingdetail = bookingManager.GetBookingDetailByClient(bookingId);

            return bookingdetail;
        }

        [HttpGet]
        [Route("DetailBookingByLoggedUser")]
        public BookingDTO GetBookingDetailByLoggedUser()
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(User.Identity.Name);

            BookingManager bookingManager = new BookingManager();

            var bookingdetail = bookingManager.GetBookingDetailByClient(client.Id);

            return bookingdetail;
        }

        [HttpPost]
        [Route("Add")]
        public Guid AddBooking(BookingDTO bookingDto)
        {
            ClientManager clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(User.Identity.Name);

            BookingManager bookingManager = new BookingManager();

            bookingDto.ClientId = client.Id;

            var newBookingId = bookingManager.InsertBooking(bookingDto);

            return newBookingId;
        }

        [HttpPost]
        [Route("Status")]
        public BookingDTO UpdateStatus(Guid bookingId)
        {
            BookingManager bookingManager = new BookingManager();

            var bookingDto = bookingManager.UpdateStatusBooking(bookingId);

            return bookingDto;
        }

        [HttpPost]
        [Route("Validate")]
        public BookingDTO ValidateBooking(Guid bookingId)
        {
            BookingManager bookingManager = new BookingManager();

            var bookingDto = bookingManager.ValidateBooking(bookingId);

            return bookingDto;
        }

        [HttpDelete]
        [Route("")]
        public BookingDTO CancelBooking(Guid bookingId)
        {
            BookingManager bookingManager = new BookingManager();

            var bookingDto = bookingManager.CancelBooking(bookingId);

            return bookingDto;
        }
    }
}