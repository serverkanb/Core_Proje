using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterMessageDal : GenericRepository<WriterMessage>,IWriterMessageDal
    {
        private readonly Context _context;

        public EfWriterMessageDal(Context context)
        {
            _context = context;
        }

        public List<WriterMessage> GetListBySender(string senderEmail)
        {
            return _context.WriterMessages.Where(x => x.Sender == senderEmail).ToList();
        }
        public List<WriterMessage> GetListByReceiver(string receiverEmail)
        {
            return _context.WriterMessages.Where(x => x.Receiver == receiverEmail).ToList();
        }
    }
}
