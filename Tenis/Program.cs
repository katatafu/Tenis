int body_a = 0, body_b = 0, body_;
int gamy_a = 0, gamy_b = 0, gamy_;
int sety_a = 0, sety_b = 0, sety_;
bool vyhody_a = false, vyhody_b = false;
string[] bodyStav = { "0", "15", "30", "40" };

while (true)
{
    Console.Clear();
    VypisSkore(sety_a, sety_b, gamy_a, gamy_b, body_a, body_b, vyhody_a, vyhody_b, bodyStav);
    Console.WriteLine("Ovládání:\n 0 - bod Hráče A\n 1 - bod Hráče B");
    int vstup;
    if (!int.TryParse(Console.ReadLine(), out vstup)) continue;

    switch (vstup)
    {
        case 0:
            ZpracujBod(ref body_a, ref body_b, ref gamy_a, ref gamy_b, ref sety_a, ref vyhody_a, ref vyhody_b, 'A');
            break;
        case 1:
            ZpracujBod(ref body_b, ref body_a, ref gamy_b, ref gamy_a, ref sety_b, ref vyhody_b, ref vyhody_a, 'B');
            break;
    }
}
static void VypisSkore(int setA, int setB, int gameA, int gameB, int bodA, int bodB, bool vyhA, bool vyhB, string[] bodyStavy)
{
    Console.WriteLine("-------= TENIS =--------");
    if (bodA == 3 && bodB == 3)
    {
        if (vyhA)
            Console.WriteLine("Výhoda Hráč A");
        else if (vyhB)
            Console.WriteLine("Výhoda Hráč B");
        else
            Console.WriteLine("Shoda");
    }
    else
    {
        Console.WriteLine($"Hráč A: {setA} | {gameA} | {bodyStavy[bodA]}");
        Console.WriteLine($"Hráč B: {setB} | {gameB} | {bodyStavy[bodB]}");
    }
    Console.WriteLine("------------------------");
}
static void ZpracujBod(ref int body_vitez, ref int body_proti, ref int gamy_vitez, ref int gamy_proti,
                            ref int sety_vitez, ref bool vyhoda_vitez, ref bool vyhoda_proti, char hrac)
{
    if (body_vitez == 3 && body_proti == 3)
    {
        if (vyhoda_vitez)
        {
            Console.WriteLine($"Hráč {hrac} vyhrává hru!");
            gamy_vitez++;
            ResetBody(ref body_vitez, ref body_proti, ref vyhoda_vitez, ref vyhoda_proti);
            if (ZkontrolujSety(ref gamy_vitez, ref gamy_proti, ref sety_vitez))
                Console.WriteLine($" Hráč {hrac} vyhrává set!");
        }
        else if (vyhoda_proti)
        {
            vyhoda_proti = false;
        }
        else
        {
            vyhoda_vitez = true;
        }
    }
    else if (body_vitez < 3)
    {
        body_vitez++;
    }
    else if (body_vitez == 3 && body_proti < 3)
    {
        Console.WriteLine($"Hráč {hrac} vyhrává hru!");
        gamy_vitez++;
        ResetBody(ref body_vitez, ref body_proti, ref vyhoda_vitez, ref vyhoda_proti);
        if (ZkontrolujSety(ref gamy_vitez, ref gamy_proti, ref sety_vitez))
            Console.WriteLine($" Hráč {hrac} vyhrává set!");
    }
}
static void ResetBody(ref int a, ref int b, ref bool va, ref bool vb)
{
    a = 0;
    b = 0;
    va = false;
    vb = false;
}

static bool ZkontrolujSety(ref int gamy_vitez, ref int gamy_proti, ref int sety_vitez)
{
    if (gamy_vitez >= 6 && gamy_vitez - gamy_proti >= 2)
    {
        sety_vitez++;
        gamy_vitez = gamy_proti = 0;
        return true;
    }
    return false;
}