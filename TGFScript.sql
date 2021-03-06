USE [master]
GO
/****** Object:  Database [TGF]    Script Date: 10/19/2012 14:39:35 ******/
CREATE DATABASE [TGF] ON  PRIMARY 
( NAME = N'TGF', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TGF.mdf' , SIZE = 31744KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TGF_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TGF_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TGF] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TGF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TGF] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TGF] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TGF] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TGF] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TGF] SET ARITHABORT OFF
GO
ALTER DATABASE [TGF] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TGF] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TGF] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TGF] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TGF] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TGF] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TGF] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TGF] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TGF] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TGF] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TGF] SET  DISABLE_BROKER
GO
ALTER DATABASE [TGF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TGF] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TGF] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TGF] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TGF] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TGF] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TGF] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TGF] SET  READ_WRITE
GO
ALTER DATABASE [TGF] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TGF] SET  MULTI_USER
GO
ALTER DATABASE [TGF] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TGF] SET DB_CHAINING OFF
GO
USE [TGF]
GO
/****** Object:  Table [dbo].[TerminationReason]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TerminationReason](
	[TerminationReasonID] [uniqueidentifier] NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Inputdate] [datetime] NULL,
	[InputBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TerminationReasonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateTaxable]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[StateTaxable](
	[StateTaxableID] [uniqueidentifier] NOT NULL,
	[StateID] [uniqueidentifier] NOT NULL,
	[Code] [varchar](50) NULL,
	[Inputdate] [datetime] NULL,
	[Inputby] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateTaxableID] ASC,
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[States]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[States](
	[StateID] [uniqueidentifier] NOT NULL,
	[State] [char](2) NOT NULL,
	[Name] [varchar](50) NULL,
	[ModifyTax] [bit] NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC,
	[State] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Division]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division](
	[DivisionID] [uniqueidentifier] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Prefix] [varchar](10) NULL,
	[GLNum] [varchar](20) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](2) NULL,
	[Zip] [varchar](10) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[ComplaintEmail] [varchar](50) NULL,
	[VendorInstructions] [text] NULL,
	[AutofaxNotice] [text] NULL,
	[Inputdate] [datetime] NULL,
	[InputBy] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DivisionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorGrades]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorGrades](
	[GradeID] [uniqueidentifier] NOT NULL,
	[Grade] [nvarchar](50) NULL,
 CONSTRAINT [PK__VendorGrades__3282355A] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors_Audit]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendors_Audit](
	[VendorAuditID] [uniqueidentifier] NOT NULL,
	[Vendnum] [int] NOT NULL,
	[Fieldname] [varchar](100) NULL,
	[OldValue] [varchar](255) NULL,
	[NewValue] [varchar](255) NULL,
	[UpdateDate] [datetime] NULL,
	[Username] [varchar](30) NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [nvarchar](50) NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifieddate] [datetime] NULL,
 CONSTRAINT [PK_Vendors_Audit] PRIMARY KEY CLUSTERED 
(
	[VendorAuditID] ASC,
	[Vendnum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[VendorID] [uniqueidentifier] NOT NULL,
	[Vendnum] [int] NOT NULL,
	[Company] [nvarchar](100) NULL,
	[DBA] [nvarchar](100) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Zip] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[Province] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[PhoneExt] [int] NULL,
	[Fax] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Emergency] [nvarchar](20) NULL,
	[Contact] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[AutoEmail] [text] NULL,
	[Comment] [text] NULL,
	[VendorType] [uniqueidentifier] NULL,
	[GLnum] [nvarchar](50) NULL,
	[TaxID] [nvarchar](50) NULL,
	[NetDays] [int] NULL,
	[CheckTax1099] [bit] NULL,
	[PVA] [bit] NULL,
	[SignedContract] [bit] NULL,
	[CreditCardHolder] [bit] NULL,
	[W9] [bit] NULL,
	[PaymentTerms] [uniqueidentifier] NULL,
	[CashDiscount] [uniqueidentifier] NULL,
	[PricingYear] [nvarchar](50) NULL,
	[Overallrating] [int] NULL,
	[WebAccessUser] [nvarchar](50) NULL,
	[WebAccessPwd] [nvarchar](50) NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [date] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [date] NULL,
	[GradeID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Vendors_1] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorRemitToTypes]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorRemitToTypes](
	[VendorRemiToTypeID] [uniqueidentifier] NOT NULL,
	[RemitToTypes] [nvarchar](50) NULL,
	[Inputby] [nvarchar](50) NULL,
	[Inputdate] [date] NULL,
	[LastModifiedby] [nvarchar](50) NULL,
	[LastModifiedDate] [date] NULL,
 CONSTRAINT [PK_VendorRemitToTypes_1] PRIMARY KEY CLUSTERED 
(
	[VendorRemiToTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorInsuranceTypes]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorInsuranceTypes](
	[InsuranceTypeID] [uniqueidentifier] NOT NULL,
	[InsuranceType] [nvarchar](50) NULL,
 CONSTRAINT [PK__VendorTypes__3282355A] PRIMARY KEY CLUSTERED 
(
	[InsuranceTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorsSearch]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorsSearch](
	[RecNo] [int] IDENTITY(1000,1) NOT NULL,
	[MAC] [varchar](50) NULL,
	[Vendnum] [int] NULL,
	[Company] [varchar](100) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](2) NULL,
	[Zip] [varchar](10) NULL,
	[DBA] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Emergency] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[Contact] [varchar](100) NULL,
	[ActiveType] [bit] NULL,
	[W9] [bit] NULL,
	[GLnum] [varchar](20) NULL,
	[ADPnum] [varchar](50) NULL,
	[NetDays] [int] NULL,
	[TaxID] [varchar](50) NULL,
	[Tax1099] [money] NULL,
	[Tax1099YN] [bit] NULL,
	[TermDay] [int] NULL,
	[Terms] [varchar](50) NULL,
	[TermDiscount] [decimal](18, 4) NULL,
	[VendorType] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Comment] [text] NULL,
	[WebUsername] [varchar](50) NULL,
	[WebPassword] [varchar](50) NULL,
	[Insurance1] [varchar](50) NULL,
	[Policy1] [varchar](50) NULL,
	[ExpDate1] [datetime] NULL,
	[Limit1] [money] NULL,
	[Exempt1] [bit] NULL,
	[Insured1] [bit] NULL,
	[Insurance2] [varchar](50) NULL,
	[Policy2] [varchar](50) NULL,
	[ExpDate2] [datetime] NULL,
	[Limit2] [money] NULL,
	[Exempt2] [bit] NULL,
	[Insured2] [bit] NULL,
	[Insurance3] [varchar](50) NULL,
	[Policy3] [varchar](50) NULL,
	[ExpDate3] [datetime] NULL,
	[Limit3] [money] NULL,
	[Exempt3] [bit] NULL,
	[Insured3] [bit] NULL,
	[TerminatedDate] [datetime] NULL,
	[TerminatedEffDate] [datetime] NULL,
	[TerminatedReason] [varchar](100) NULL,
	[TerminatedBy] [varchar](30) NULL,
	[Rehire] [char](1) NULL,
	[Grade] [varchar](50) NULL,
	[CheckCompany] [varchar](100) NULL,
	[CheckAddress1] [varchar](100) NULL,
	[CheckAddress2] [varchar](100) NULL,
	[CheckCity] [varchar](100) NULL,
	[CheckState] [varchar](2) NULL,
	[CheckZip] [varchar](10) NULL,
	[CheckContact] [varchar](50) NULL,
	[CheckPhone] [varchar](20) NULL,
	[ShipCompany] [varchar](100) NULL,
	[ShipAddress1] [varchar](100) NULL,
	[ShipAddress2] [varchar](100) NULL,
	[ShipCity] [varchar](100) NULL,
	[ShipState] [varchar](2) NULL,
	[ShipZip] [varchar](10) NULL,
	[ShipContact] [varchar](50) NULL,
	[ShipPhone] [varchar](20) NULL,
	[Recruiter] [varchar](30) NULL,
	[ReferBy] [varchar](50) NULL,
	[FactorCompany] [varchar](50) NULL,
	[FactorAddress1] [varchar](50) NULL,
	[FactorAddress2] [varchar](50) NULL,
	[FactorCity] [varchar](50) NULL,
	[FactorState] [varchar](2) NULL,
	[FactorZip] [varchar](10) NULL,
	[FactorPhone] [varchar](20) NULL,
	[FactorFax] [varchar](20) NULL,
	[FactorContact] [varchar](50) NULL,
	[Inputdate] [datetime] NULL,
	[Inputby] [varchar](30) NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[Comment1] [varchar](50) NULL,
	[Distance] [decimal](18, 4) NULL,
	[ServiceCnt] [int] NULL,
	[drivingtime] [varchar](50) NULL,
	[Dormant] [bit] NULL,
	[RateInt] [money] NULL,
	[RateExt] [money] NULL,
	[Province] [varchar](50) NULL,
	[EmailAutoFax] [varchar](100) NULL,
	[PriceCnt] [int] NULL,
	[NP] [int] NULL,
	[SC] [int] NULL,
	[LP] [int] NULL,
	[SV] [int] NULL,
	[TermSV] [int] NULL,
	[TermLP] [int] NULL,
	[TermNP] [int] NULL,
	[TermSC] [int] NULL,
	[SignedContract] [bit] NULL,
	[VPA] [bit] NULL,
	[InsuranceWaiver] [bit] NULL,
	[InsuranceWaiverReason] [varchar](50) NULL,
 CONSTRAINT [PK_VendorsSearch] PRIMARY KEY CLUSTERED 
(
	[RecNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorTypes]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorTypes](
	[VendorTypeID] [uniqueidentifier] NOT NULL,
	[VendorType] [nchar](10) NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [date] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [date] NULL,
 CONSTRAINT [PK_VendorTypes_1] PRIMARY KEY CLUSTERED 
(
	[VendorTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorTermination]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorTermination](
	[VendorTerminationID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[TerminationDate] [datetime] NULL,
	[TerminationEffDate] [datetime] NULL,
	[TerminatedBy] [nvarchar](50) NULL,
	[TerminationReason] [uniqueidentifier] NULL,
	[Rehire] [nchar](1) NULL,
	[Division] [uniqueidentifier] NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [datetime] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_VendorTermination_1] PRIMARY KEY CLUSTERED 
(
	[VendorTerminationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorShipTo]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorShipTo](
	[VendorShipToID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[Recipient] [nvarchar](100) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Phone] [nvarchar](25) NULL,
	[PhoneExt] [nvarchar](10) NULL,
	[Fax] [nvarchar](25) NULL,
	[Email] [nvarchar](100) NULL,
	[InputDate] [datetime] NULL,
	[InputBy] [varchar](30) NULL,
	[LastModifiedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](30) NULL,
 CONSTRAINT [PK_VendorShipTo] PRIMARY KEY CLUSTERED 
(
	[VendorShipToID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ship To information for the vendor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorShipTo'
GO
/****** Object:  Table [dbo].[VendorInsurance]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorInsurance](
	[VendorInsuranceID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[InsuranceType] [uniqueidentifier] NULL,
	[InsuranceName] [nvarchar](50) NULL,
	[Policynum] [bigint] NULL,
	[ExpiryDate] [date] NULL,
	[AdditionalInsured] [bit] NULL,
	[Not_onFile] [bit] NULL,
	[InsuranceNotRequired] [bit] NULL,
	[NotRequiredReason] [nvarchar](100) NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [date] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [date] NULL,
 CONSTRAINT [PK_VendorInsurance_1] PRIMARY KEY CLUSTERED 
(
	[VendorInsuranceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorRemitTo]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorRemitTo](
	[VendorRemitToID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[Company] [nvarchar](100) NULL,
	[RemitType] [nvarchar](50) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](10) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[PhoneExt] [int] NULL,
	[Contact] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [date] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [date] NULL,
 CONSTRAINT [PK_VendorRemitTo_1] PRIMARY KEY CLUSTERED 
(
	[VendorRemitToID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorNotes]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorNotes](
	[VendorNotesID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[NoteType] [varchar](50) NULL,
	[Notes] [text] NULL,
	[InputStatus] [varchar](10) NULL,
	[MakePublic] [bit] NULL,
	[InputDate] [datetime] NULL,
	[InputBy] [varchar](30) NULL,
	[LastModifiedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](30) NULL,
 CONSTRAINT [PK_VendorNotes] PRIMARY KEY CLUSTERED 
(
	[VendorNotesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VendorFeedbacks]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendorFeedbacks](
	[VendorFeedbackID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[FeedbackSubject] [nvarchar](50) NULL,
	[Feedback] [text] NULL,
	[Ratings] [int] NULL,
	[InputBy] [nvarchar](50) NULL,
	[InputDate] [datetime] NULL,
	[LastModifiedBy] [nvarchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_VendorFeedbacks_1] PRIMARY KEY CLUSTERED 
(
	[VendorFeedbackID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VendorContacts]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorContacts](
	[VendorContactID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[Lastname] [nvarchar](50) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Phone] [nvarchar](25) NULL,
	[PhoneExt] [nvarchar](10) NULL,
	[Fax] [nvarchar](25) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[ContactType] [varchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Notes] [text] NULL,
	[ActiveType] [bit] NULL,
	[InputDate] [datetime] NULL,
	[InputBy] [varchar](30) NULL,
	[LastModifiedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](30) NULL,
 CONSTRAINT [PK__VendorContacts__63E3BB6D] PRIMARY KEY CLUSTERED 
(
	[VendorContactID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vendor Contacts are the contacts of the vendor.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VendorContacts'
GO
/****** Object:  Table [dbo].[VendorCategory]    Script Date: 10/19/2012 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VendorCategory](
	[VendorCategoryID] [uniqueidentifier] NOT NULL,
	[VendorID] [uniqueidentifier] NOT NULL,
	[VendorType] [varchar](50) NULL,
	[MasterType] [bit] NULL,
	[Inputdate] [datetime] NULL,
	[inputby] [nvarchar](50) NULL,
 CONSTRAINT [PK__VendorCategory__351DDF8C] PRIMARY KEY CLUSTERED 
(
	[VendorCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_TerminationReason_TerminationReasonID]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[TerminationReason] ADD  CONSTRAINT [DF_TerminationReason_TerminationReasonID]  DEFAULT (newid()) FOR [TerminationReasonID]
GO
/****** Object:  Default [DF__StateTaxa__Input__4E88ABD4]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[StateTaxable] ADD  DEFAULT (getdate()) FOR [Inputdate]
GO
/****** Object:  Default [DF__StateTaxa__Input__4F7CD00D]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[StateTaxable] ADD  DEFAULT ('') FOR [Inputby]
GO
/****** Object:  Default [DF__States__ModifyTa__49C3F6B7]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[States] ADD  DEFAULT ((0)) FOR [ModifyTax]
GO
/****** Object:  Default [DF_Division_DivisionID]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[Division] ADD  CONSTRAINT [DF_Division_DivisionID]  DEFAULT (newid()) FOR [DivisionID]
GO
/****** Object:  Default [DF__Vendors_A__Updat__56D4A469]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[Vendors_Audit] ADD  CONSTRAINT [DF__Vendors_A__Updat__56D4A469]  DEFAULT (getdate()) FOR [UpdateDate]
GO
/****** Object:  Default [DF_Vendors_VendorID]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[Vendors] ADD  CONSTRAINT [DF_Vendors_VendorID]  DEFAULT (newid()) FOR [VendorID]
GO
/****** Object:  Default [DF_Vendors_LastModifiedDate]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[Vendors] ADD  CONSTRAINT [DF_Vendors_LastModifiedDate]  DEFAULT (getdate()) FOR [LastModifiedDate]
GO
/****** Object:  Default [DF_VendorsSearch_Dormant]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorsSearch] ADD  CONSTRAINT [DF_VendorsSearch_Dormant]  DEFAULT ((0)) FOR [Dormant]
GO
/****** Object:  Default [DF__VendorsSearc__NP__3123FCCD]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorsSearch] ADD  CONSTRAINT [DF__VendorsSearc__NP__3123FCCD]  DEFAULT ((0)) FOR [NP]
GO
/****** Object:  Default [DF__VendorsSearc__SC__32182106]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorsSearch] ADD  CONSTRAINT [DF__VendorsSearc__SC__32182106]  DEFAULT ((0)) FOR [SC]
GO
/****** Object:  Default [DF__VendorsSearc__LP__330C453F]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorsSearch] ADD  CONSTRAINT [DF__VendorsSearc__LP__330C453F]  DEFAULT ((0)) FOR [LP]
GO
/****** Object:  Default [DF__VendorsSearc__SV__34006978]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorsSearch] ADD  CONSTRAINT [DF__VendorsSearc__SV__34006978]  DEFAULT ((0)) FOR [SV]
GO
/****** Object:  Default [DF_VendorInsurance_VendorInsuranceID]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorInsurance] ADD  CONSTRAINT [DF_VendorInsurance_VendorInsuranceID]  DEFAULT (newid()) FOR [VendorInsuranceID]
GO
/****** Object:  Default [DF_VendorContacts_VendorID]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorContacts] ADD  CONSTRAINT [DF_VendorContacts_VendorID]  DEFAULT (newid()) FOR [VendorContactID]
GO
/****** Object:  Default [DF_VendorContacts_LastModifiedDate]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorContacts] ADD  CONSTRAINT [DF_VendorContacts_LastModifiedDate]  DEFAULT (getdate()) FOR [LastModifiedDate]
GO
/****** Object:  ForeignKey [FK_VendorTermination_Division]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorTermination]  WITH CHECK ADD  CONSTRAINT [FK_VendorTermination_Division] FOREIGN KEY([Division])
REFERENCES [dbo].[Division] ([DivisionID])
GO
ALTER TABLE [dbo].[VendorTermination] CHECK CONSTRAINT [FK_VendorTermination_Division]
GO
/****** Object:  ForeignKey [FK_VendorTermination_TerminationReason]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorTermination]  WITH CHECK ADD  CONSTRAINT [FK_VendorTermination_TerminationReason] FOREIGN KEY([TerminationReason])
REFERENCES [dbo].[TerminationReason] ([TerminationReasonID])
GO
ALTER TABLE [dbo].[VendorTermination] CHECK CONSTRAINT [FK_VendorTermination_TerminationReason]
GO
/****** Object:  ForeignKey [FK_VendorTermination_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorTermination]  WITH CHECK ADD  CONSTRAINT [FK_VendorTermination_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorTermination] CHECK CONSTRAINT [FK_VendorTermination_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorShipTo_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorShipTo]  WITH CHECK ADD  CONSTRAINT [FK_VendorShipTo_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorShipTo] CHECK CONSTRAINT [FK_VendorShipTo_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorInsurance_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorInsurance]  WITH CHECK ADD  CONSTRAINT [FK_VendorInsurance_Vendors] FOREIGN KEY([InsuranceType])
REFERENCES [dbo].[VendorInsuranceTypes] ([InsuranceTypeID])
GO
ALTER TABLE [dbo].[VendorInsurance] CHECK CONSTRAINT [FK_VendorInsurance_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorInsurance_Vendors1]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorInsurance]  WITH CHECK ADD  CONSTRAINT [FK_VendorInsurance_Vendors1] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorInsurance] CHECK CONSTRAINT [FK_VendorInsurance_Vendors1]
GO
/****** Object:  ForeignKey [FK_VendorRemitTo_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorRemitTo]  WITH CHECK ADD  CONSTRAINT [FK_VendorRemitTo_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorRemitTo] CHECK CONSTRAINT [FK_VendorRemitTo_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorNotes_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorNotes]  WITH CHECK ADD  CONSTRAINT [FK_VendorNotes_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorNotes] CHECK CONSTRAINT [FK_VendorNotes_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorFeedbacks_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorFeedbacks]  WITH CHECK ADD  CONSTRAINT [FK_VendorFeedbacks_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorFeedbacks] CHECK CONSTRAINT [FK_VendorFeedbacks_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorContacts_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorContacts]  WITH CHECK ADD  CONSTRAINT [FK_VendorContacts_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorContacts] CHECK CONSTRAINT [FK_VendorContacts_Vendors]
GO
/****** Object:  ForeignKey [FK_VendorCategory_Vendors]    Script Date: 10/19/2012 14:39:36 ******/
ALTER TABLE [dbo].[VendorCategory]  WITH CHECK ADD  CONSTRAINT [FK_VendorCategory_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([VendorID])
GO
ALTER TABLE [dbo].[VendorCategory] CHECK CONSTRAINT [FK_VendorCategory_Vendors]
GO
