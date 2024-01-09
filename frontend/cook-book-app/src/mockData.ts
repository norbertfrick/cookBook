import { Recipe } from "./model/recipe";
import { RecipeDetail } from "./model/recipeDetail";

export const mockData: Recipe[] = 
    [
        {
            Id: "1",
            Title: "Skvela kolozvarska dobrota",
            Description: "Najlepsia kolozvarska kapusta tvojho zivota",
            PictureUrl: "https://s.aktuality.sk/img/L7I9E8fiRU_m_FwSyLdLgQ.jpg?st=DytaTCj951XfdqA4ujPShwaQFJjZ_NC04Ony0RWtPRA&ts=1614339081&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: ["Popicovky"]

        },
        {
            Id: "2",
            Title: "Fakt chutna zemlovka premium",
            Description: "Taka zemlovka, ze ani neveris, ze nie je zo zemli",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        },
        {
            Id: "3",
            Title: "Priemerne chutna zemlovka",
            Description: "Priemerne chutna zemlovka zo zemle",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        },
        {
            Id: "4",
            Title: "Domácí BigMac burger",
            Description: "Perfektní domácí BigMac burger, který chutná lépe než originál díky své čerstvosti",
            PictureUrl: "",
            UserId:"1",
            User: "Norqo",
            Tags: ["Popicovky"]

        },
        {
            Id: "5",
            Title: "Fakt chutna zemlovka premium",
            Description: "Taka zemlovka, ze ani neveris, ze nie je zo zemli",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        },
        {
            Id: "6",
            Title: "Priemerne chutna zemlovka",
            Description: "Priemerne chutna zemlovka zo zemle",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        },
        {
            Id: "7",
            Title: "Skvela kolozvarska dobrota",
            Description: "Najlepsia kolozvarska kapusta tvojho zivota",
            PictureUrl: "https://s.aktuality.sk/img/L7I9E8fiRU_m_FwSyLdLgQ.jpg?st=DytaTCj951XfdqA4ujPShwaQFJjZ_NC04Ony0RWtPRA&ts=1614339081&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: ["Popicovky"]

        },
        {
            Id: "8",
            Title: "Fakt chutna zemlovka premium",
            Description: "Taka zemlovka, ze ani neveris, ze nie je zo zemli",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        },
        {
            Id: "9",
            Title: "Priemerne chutna zemlovka",
            Description: "Priemerne chutna zemlovka zo zemle",
            PictureUrl: "https://s.aktuality.sk/img/EmBGYmR7QgC6FWINqN1Lag.jpg?st=50dHKotvePsnnUIofbKOrzzGKw4JxzT1O7d81Mt14EA&ts=1533282094&e=0",
            User: "Norqo",
            UserId:"1",
            Tags: []
        }
    ]

    export const mockDetails: RecipeDetail[] = [
        {
            Id: "1",
            RecipeId: "4",
            Steps: [
                { 
                    ordinal: 1,
                    description: "Hovězí maso umeleme, lehce prosolíme a opepříme. Z masa vytvoříme na pečícím papíru (nelepí) placky vysoké necelý centimetr a o dost větší než bulka (maso se při pečení smrskne). Dále si připravíme dressing smícháním celé majonézy s lžící (dle chuti) hořčice, nasekaných okurek, lžičky octa a dvou lžiček cukru, nasekané cibule - hodně, soli a pepře. Dressing na chvíli odložíme do lednice. Nasekáme si ledový salát na úzké nudle a okurky na plátky."

                }, 
                { 
                    ordinal: 2,
                    description: "Bulky překrojíme na tři plátky, tak aby nám vznikl vršek, střed a spodek BigMacka. Na rozpálené pánvi opečeme burgery z každé strany cca 1-2 minuty, posolíme a popepříme. Hned po nich na pánvi opečeme bulky po překrojených stranách do zlatohněda. Samozřejmě lze připravit i na grilu... :)"
                },
                { 
                    ordinal: 3,
                    description: "Domácí BigMac burger skládáme tak, že na spodek housky dáme lžíci dressingu, nasekanou cibuli, salát, plátky kyselých okurek, maso, střed housky, dressing, cibuli, salát, plátky okurek, maso, sýr a přiklopíme vrchním dílem housky.                    "
                },

            ],
            Ingredients: [
                {
                    amount:0.5, 
                    unit:"sklenice",
                    description: "majoneza"
                },
                {
                    amount:0.5, 
                    unit:"lyzica",
                    description: "horcica"
                },
                {
                    amount:75, 
                    unit:"gramov",
                    description: "hovadzie maso"
                },
                {
                    amount:0.5, 
                    unit:"hlavky",
                    description: "salat"
                },
                {
                    amount:1, 
                    unit:"kus",
                    description: "zemla"
                },

            ], 
            TimeToCook: 123,
            Servings: 2

        }
    ]