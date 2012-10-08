using BroadwayNext_Sprint_0_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadwayNext_Sprint_0_1.Data
{
    public class UnitOfWork : IDisposable
    {

        private TGFContext DbContext;
        private EFRepository<Vendor> vendorRepository;
        private EFRepository<VendorRemitTo> remitToRepository;
        private EFRepository<VendorContact> vendorContactRepository;

        public UnitOfWork()
        {
            CreateDbContext();

            //repositoryProvider.DbContext = DbContext;
            //RepositoryProvider = repositoryProvider;       
        }

        //----------------------------
        //Application Repositories...

        public EFRepository<Vendor> Vendors
        {
            get
            {
                if (this.vendorRepository == null)
                {
                    this.vendorRepository = new EFRepository<Vendor>(DbContext);
                }
                return vendorRepository;
            }
        }
        public EFRepository<VendorRemitTo> RemitTo
        {
            get
            {
                if (this.remitToRepository == null)
                {
                    this.remitToRepository = new EFRepository<VendorRemitTo>(DbContext);
                }
                return remitToRepository;
            }
        }
        public EFRepository<VendorContact> VendorContacts
        {
            get
            {
                if (this.vendorContactRepository == null)
                {
                    this.vendorContactRepository = new EFRepository<VendorContact>(DbContext);
                }
                return vendorContactRepository;
            }
        }
        //----------------------------

        protected void CreateDbContext()
        {
            DbContext = new TGFContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;

        }

        public int Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            return DbContext.SaveChanges();

        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

    }
}
