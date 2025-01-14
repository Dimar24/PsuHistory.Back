﻿using PsuHistory.Data.Domain.Models.Monuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistory.Data.EF.SQL.Data
{
    public static class BurialInitialization
    {
        public static List<Burial> GetBurialInitialization(List<TypeBurial> typeBurials, DateTime dateTimeInitialization)
        {
            var id = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id;

            var burials = new List<Burial>()
            {
                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 2353,
                    Location = "г. Полопцк, Боровуха-2",
                    KnownNumber = 183,
                    UnknownNumber = 327,
                    Year = 1955,
                    Latitude = 55.585541,
                    Longitude = 28.581422,
                    Description = "В 2007 году памятник реконструирован, установлена гранитная стела высотой 4 м и гранитные доски на постаментах с именами погибших. Основание для увековечения: похоронены воины 119-й, 311-й, 360-й стрелковых дивизий, которые погибли в боях за освобождение г. Полоцка; воины, которые умерли от ран и болезней в эвакогоспиталях № 3329, № 3438, кроме того, в 1960 г. сюда перезахоронены неизвестный солдат из одиночной могилы, которая находилась возле здания СШ № 6, а также танкист В.М. Малявко из одиночной могилы, которая находилась на территории воинской части; 11 воинов, которые были похоронены в поселке Боровуха-3. А в 2005 г. сюда перезахоронены останки 356 военнослужащих РККА, обнаруженных при поисковых работах с раскопками в районе ул. Вологина (200 м. севернее ДОСа № 371). Из них установлены 3 фамилии: Бритвин А.В., Лебедев А.И., Ушаков И.Г. ",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 4250,
                    Location = "г. Полопцк, пл. Свободы",
                    KnownNumber = 16,
                    UnknownNumber = 0,
                    Year = 1944,
                    Latitude = 55.585541,
                    Longitude = 28.581422,
                    Description = "Основание увековечить – по решению Военного Совета 1-го Прибалтийского фронта, здесь были захоронены 15 командиров частей и подразделений, участвовавших  в освобождении Полоцка и Полоцкого района. Инициатор – Военный Совет 1-го Прибалтийского фронта и Полоцкий городской исполнительный комитет. Автор мемориальной экспозиции – по 1981 г. архитектор В. Аладов, скульптор Г. Муромцев. Материал памятника – бронза, гранит, бетон. В центре стела (15×5×3 м), облицованная серым гранитом. Справа на стеле бронзовый горельеф с изображением трех воинов (раненный воин, воин с автоматом и воин со знаменем), слева – памятная надпись. На левой боковой грани и на титульной стороне стелы – бронзовые доски с текстом Приказа Верховного главнокомандующего Вооруженными силами СССР по случаю освобождения города с перечислением войсковых частей, которые освобождали Полоцк от немецко-фашистских захватчиков, и частей, которые получили почетное наименование «Полоцких». Перед стелой темно-красное гранитное надгробие (3×3) с именами захороненных. Текст оснвной надписи – «Освободителям Полоцка».",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 4251,
                    Location = "г. Полопцк, Громовское клабдище",
                    KnownNumber = 459,
                    UnknownNumber = 0,
                    Year = 1944,
                    Latitude = 55.490717,
                    Longitude = 28.81554,
                    Description = "Основание увековечения — первичное место захоронения воинов 47-й и 51-й сд 22-го гвск, погибшие при освобождении г. Полоцка с 2 по 4 июля 1944 г. а также солдат, умерших от полученных на фронте ран в госпитале № 2918. Автор мемориальной экспозиции - неизвестен. Материал памятника — обелиск был изготовлен из бетона, оштукатуренный. Высота - 4 м., в плане 2х3 м., обнесён металлической оградой Текст надписи — «Вечная память героям павшим в боях за свободу нашей Родины».",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 4252,
                    Location = "г. Полопцк, ул. Дзержинского, Фатыновское кладбище",
                    KnownNumber = 93,
                    UnknownNumber = 0,
                    Year = 1949,
                    Latitude = 55.479171,
                    Longitude = 28.763218,
                    Description = "Основание увековечения — захоронены воины 71-й гв. сд, 51-й гв. сд и танкисты 47-го отд. огнеметного танкового полка и 19 отд. инженерно-танкового полка, погибшие при освобождении г. Полоцка с 1 по 4 июля 1944, года, а также солдаты, умершие от полученных на фронте ран в госпиталях № 1319 и № 733. Автор мемориальной экспозиции - неизвестен. Материал памятника - обелиск был изготовлен из бетона, оштукатуренный. Высота - 4 м., в плане 2х3 м. обнесён металлической оградой. Текст надписи — «Вечная слава и память героям, погибшим за освобождение г Полоцка от немецко-фашистских захватчиков».",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 4253,
                    Location = "г. Полопцк, ул. Гагарина, Красное кладбище",
                    KnownNumber = 44,
                    UnknownNumber = 156,
                    Year = 1984,
                    Latitude = 55.483743,
                    Longitude = 28.803708,
                    Description = "Основание увековечения — захоронены воины, которые умерли от ран и болезней в эвакогоспитале № 1969, сортировальном эвакогоспитале № 1822 и сортировально-полевом передвижном госпитале № 2479 Автор мемориальной экспозиции — автор А.Ф. Сидюк. Материол памятника - железобетонная стена с изображением звезды и накладным текстом, высота 2 м, длина 9 м. Текст надписи -— «В память о 160-и советских воинах, погибших при освобождении города Полоцка от немецко-фашистских захватчиков».",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = string.Empty,
                    NumberBurial = 4254,
                    Location = "г. Полопцк, ул. 4-й пер. Фрунзе, Ксаверьевское кладбище",
                    KnownNumber = 11,
                    UnknownNumber = 4,
                    Year = 1951,
                    Latitude = 55.498715,
                    Longitude = 28.778089,
                    Description = "Основание увековечения — захоронены воины, умершие от полученных ранений в госпитали № 1105 на протяжении с июля по 1 ноября 1944 г. Автор мемориальной экспозиции — архитектор Глазунов Н.П Материал памятника - железобетонный белиск, высота 4,8 м, в плане 4,3х5/ м, обнесен металлической оградой.",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },

                new Burial()
                {
                    Name = "Место массового уничтожения Мемориальный комплекс памяти жертв нацизма «Урочище пески»",
                    NumberBurial = 6807,
                    Location = "г. Полопцк, урочище Пески",
                    KnownNumber = 107,
                    UnknownNumber = 37894,
                    Year = 0,
                    Latitude = 55.506784,
                    Longitude = 28.784838,
                    Description = "Железобетонная стела на символической могиле, установленная в 1955 году, на которой расположена информационная табличка. Строительство мемориального комплекса начато в 2010 г и продолжается по настоящее время. Захоронены останки десятков тысяч военнопленных Дулага-125, подпольщиков, партизан и мирных жителей, погибших от рук нацистов и их пособников в 1941 - 1944. гг.",
                    TypeBurialId = typeBurials.FirstOrDefault(d => d.Name.Equals("Братская могила")).Id,
                },
            };

            burials.ForEach(d =>
            {
                d.Id = Guid.NewGuid();
                d.CreatedAt = dateTimeInitialization;
                d.UpdatedAt = dateTimeInitialization;
            });

            return burials;
        }
    }
}
