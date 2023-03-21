﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using telecomNevaSvyaz_2.Classes;

namespace telecomNevaSvyaz_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Subscribe.xaml
    /// </summary>
    public partial class Subscribe : Page
    {
        public Subscribe(Subscriber subscriber)
        {
            InitializeComponent();
            tbSubscriberNomer.Text = tbSubscriberNomer.Text + subscriber.SubscriberNomer; // Заполнения данных о пользователе
            tbSurname.Text = tbSurname.Text + subscriber.Surname;
            tbName.Text = tbName.Text + subscriber.Name;
            tbPatronymic.Text = tbPatronymic.Text + subscriber.Patronymic;
            tbPlace0fResidence.Text = tbPlace0fResidence.Text + subscriber.Place0fResidence;
            tbResidentialAddress.Text = tbResidentialAddress.Text + subscriber.ResidentialAddress.Rayon.RaionName + ", " + subscriber.ResidentialAddress.City.City1 + " " + subscriber.ResidentialAddress.Street.Street1 + " " + subscriber.ResidentialAddress.House;
            tbSeria.Text = tbSeria.Text + subscriber.Seria; // Формирование паспортных данных
            tbNomer.Text = tbNomer.Text + subscriber.Nomer;
            tbDateOfIssue.Text = tbDateOfIssue.Text + subscriber.DateOfIssue.ToString("d");
            tbIssuedBy.Text = tbIssuedBy.Text + subscriber.IssuedBy;
            tbContractNumber.Text = tbContractNumber.Text + subscriber.Contracts.ContractNumber; // Формирование данных о договоре абонента
            tbDateOfCinclusion.Text = tbDateOfCinclusion.Text + subscriber.Contracts.DateOfCinclusion.ToString("d");
            tbTypeContract.Text = tbTypeContract.Text + subscriber.Contracts.ContractType.TypeContract;
            tbPersonalAccount.Text = tbPersonalAccount.Text + subscriber.Contracts.PersonalAccount;
            if (subscriber.Contracts.TermibationDate != null) // Если договор расторгнут
            {
                tbTermibationDate.Text = tbTermibationDate.Text + Convert.ToDateTime(subscriber.Contracts.TermibationDate).ToString("d");
                tbReasonForTermination.Text = tbReasonForTermination.Text + subscriber.Contracts.TerminationReason.ReasonForTermination;
            }
            else
            {
                tbTermibationDate.Text = "";
                tbTermibationDate.Visibility = Visibility.Collapsed;
                tbReasonForTermination.Text = "";
                tbReasonForTermination.Visibility = Visibility.Collapsed;
            }
            List<ConnectedServices> connectedServices = DBHelper.bm.ConnectedServices.Where(x => x.SubscribersID == subscriber.SubscriberID).ToList(); // Формирование списка подключенных услуг с датой подключения
            for (int i = 0; i < connectedServices.Count; i++)
            {
                if (i == connectedServices.Count - 1) // Если последний эллемент, то на новую строку не переходим
                {
                    if (connectedServices[i].ConnectionDate != null) // Если указана дата подключения
                    {
                        listService.Text = listService.Text + connectedServices[i].Service.Services + " Дата подключения: " + Convert.ToDateTime(connectedServices[i].ConnectionDate).ToString("d");
                    }
                    else
                    {
                        listService.Text = listService.Text + connectedServices[i].Service.Services;
                    }
                }
                else
                {
                    if (connectedServices[i].ConnectionDate != null) // Если указана дата подключения
                    {
                        listService.Text = listService.Text + connectedServices[i].Service.Services + " Дата подключения: " + Convert.ToDateTime(connectedServices[i].ConnectionDate).ToString("d") + "\n";
                    }
                    else
                    {
                        listService.Text = listService.Text + connectedServices[i].Service.Services + "\n";
                    }
                }
            }
            List<EquipmentInstallation> equipmentInstallations = DBHelper.bm.EquipmentInstallation.Where(x => x.SubscriberID == subscriber.SubscriberID).ToList();
            for (int i = 0; i < equipmentInstallations.Count; i++) // Формирование списка установленного оборудования
            {
                if (i == connectedServices.Count - 1) // Если последний эллемент, то на новую строку не переходим
                {
                    if (equipmentInstallations[i].Rental)
                    {
                        listEquipments.Text = listEquipments.Text + equipmentInstallations[i].Equipment.EquiomentName + " " + equipmentInstallations[i].Notes;
                    }
                    else
                    {
                        listEquipments.Text = listEquipments.Text + equipmentInstallations[i].Equipment.EquiomentName;
                    }
                }
                else
                {
                    if (equipmentInstallations[i].Rental) // Проверка если оборудование арендовано, то напишем это
                    {
                        listEquipments.Text = listEquipments.Text + equipmentInstallations[i].Equipment.EquiomentName + " " + equipmentInstallations[i].Notes + "\n";
                    }
                    else
                    {
                        listEquipments.Text = listEquipments.Text + equipmentInstallations[i].Equipment.EquiomentName + "\n";
                    }
                }
            }
            DateTime dateTime = DateTime.Now.AddMonths(-12); // Дата год назад
            List<CRM> cRMs = DBHelper.bm.CRM.Where(x => x.SubscriberID == subscriber.SubscriberID && x.DateCreation >= dateTime).ToList();
            for (int i = 0; i < cRMs.Count; i++) // Формирование списка оказанных услуг за год
            {
                if (i == cRMs.Count - 1) // Если последний элемент, то пробелы в конце не ставим
                {
                    listCRM.Text = listCRM.Text + "Номер заявки " + cRMs[i].NumberCRM + "\n";
                    listCRM.Text = listCRM.Text + "Дата создания: " + cRMs[i].DateCreation.ToString("d") + "\n";
                    if (cRMs[i].ClosingDate != null)
                    {
                        listCRM.Text = listCRM.Text + "Дата закрытия: " + Convert.ToDateTime(cRMs[i].ClosingDate).ToString("d") + "\n";
                    }
                    listCRM.Text = listCRM.Text + "Услуга: " + cRMs[i].Service.Services + "\n";
                    listCRM.Text = listCRM.Text + "Вид услуги: " + cRMs[i].TypeOfServices.TypeOfService + "\n";
                    listCRM.Text = listCRM.Text + "Тип услуги: " + cRMs[i].ServiceType.ServiceType1 + "\n";
                    listCRM.Text = listCRM.Text + "Описание проблемы: " + cRMs[i].Description;
                }
                else
                {
                    listCRM.Text = listCRM.Text + "Номер заявки " + cRMs[i].NumberCRM + "\n";
                    listCRM.Text = listCRM.Text + "Дата создания: " + cRMs[i].DateCreation + "\n";
                    if (cRMs[i].ClosingDate != null)
                    {
                        listCRM.Text = listCRM.Text + "Дата закрытия: " + cRMs[i].ClosingDate + "\n";
                    }
                    listCRM.Text = listCRM.Text + "Услуга: " + cRMs[i].Service.Services + "\n";
                    listCRM.Text = listCRM.Text + "Вид услуги: " + cRMs[i].TypeOfServices.TypeOfService + "\n";
                    listCRM.Text = listCRM.Text + "Тип услуги: " + cRMs[i].ServiceType.ServiceType1 + "\n";
                    listCRM.Text = listCRM.Text + "Описание проблемы: " + cRMs[i].Description + "\n\n";
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frameClass.mainFrame.Navigate(new SubscribersList());
        }
    }
}
