using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdeExtension
{
    /*
     -quark              Set chip-check and CPUID for Intel(R) Quark CPU
     -p4                 Set chip-check and CPUID for Intel(R) Pentium4 CPU
     -p4p                Set chip-check and CPUID for Intel(R) Pentium4 Prescott CPU
     -mrm                Set chip-check and CPUID for Intel(R) Merom CPU
     -pnr                Set chip-check and CPUID for Intel(R) Penryn CPU
     -nhm                Set chip-check and CPUID for Intel(R) Nehalem CPU
     -wsm                Set chip-check and CPUID for Intel(R) Westmere CPU
     -snb                Set chip-check and CPUID for Intel(R) Sandy Bridge CPU
     -ivb                Set chip-check and CPUID for Intel(R) Ivy Bridge CPU
     -hsw                Set chip-check and CPUID for Intel(R) Haswell CPU
     -bdw                Set chip-check and CPUID for Intel(R) Broadwell CPU
     -slt                Set chip-check and CPUID for Intel(R) Saltwell CPU
     -slm                Set chip-check and CPUID for Intel(R) Silvermont CPU
     -glm                Set chip-check and CPUID for Intel(R) Goldmont CPU
     -glp                Set chip-check and CPUID for Intel(R) Goldmont Plus CPU
     -tnt                Set chip-check and CPUID for Intel(R) Tremont CPU
     -snr                Set chip-check and CPUID for Intel(R) Snow Ridge CPU
     -skl                Set chip-check and CPUID for Intel(R) Skylake CPU
     -cnl                Set chip-check and CPUID for Intel(R) Cannon Lake CPU
     -icl                Set chip-check and CPUID for Intel(R) Ice Lake CPU
     -skx                Set chip-check and CPUID for Intel(R) Skylake server CPU
     -clx                Set chip-check and CPUID for Intel(R) Cascade Lake CPU
     -cpx                Set chip-check and CPUID for Intel(R) Cooper Lake CPU
     -icx                Set chip-check and CPUID for Intel(R) Ice Lake server CPU
     -knl                Set chip-check and CPUID for Intel(R) Knights landing CPU
     -knm                Set chip-check and CPUID for Intel(R) Knights mill CPU
     -tgl                Set chip-check and CPUID for Intel(R) Tiger Lake CPU
     -adl                Set chip-check and CPUID for Intel(R) Alder Lake CPU
     -spr                Set chip-check and CPUID for Intel(R) Sapphire Rapids CPU
     -future             Set chip-check and CPUID for Intel(R) Future chip CPU
    */

    public enum Architectures
    {
        quark,
        p4,
        p4p,
        mrm,
        pnr,
        nhm,
        wsm,
        snb,
        ivb,
        hsw,
        bdw,
        slt,
        slm,
        glm,
        glp,
        tnt,
        snr,
        skl,
        cnl,
        icl,
        skx,
        clx,
        cpx,
        icx,
        knl,
        knm,
        tgl,
        adl,
        spr,
        future,
        empty,
    }


    public class ArchitectureData
    {

        public ArchitectureData[] ArchitecturesTable;

        private readonly Architectures arch;
        private readonly string archstr;
        private readonly string longname;

        public ArchitectureData(Architectures a, string b, string c)
        {
            arch = a;
            archstr = b;
            longname = c;
        }

        public ArchitectureData() 
        {
            ArchitecturesTable = new ArchitectureData[] {
               new ArchitectureData(Architectures.quark, "quark", "Quark"),
               new ArchitectureData(Architectures.p4, "p4", "Pentium4"),
               new ArchitectureData(Architectures.p4p, "p4p", "Pentium4 Prescott"),
               new ArchitectureData(Architectures.mrm, "mrm", "Merom"),
               new ArchitectureData(Architectures.pnr, "pnr", "Penryn"),
               new ArchitectureData(Architectures.nhm, "nhm", "Nehalem"),
               new ArchitectureData(Architectures.wsm, "wsm", "Westmere"),
               new ArchitectureData(Architectures.snb, "snb", "Sandy Bridge"),
               new ArchitectureData(Architectures.ivb, "ivb", "Ivy Bridge"),
               new ArchitectureData(Architectures.hsw, "hsw", "Haswell"),
               new ArchitectureData(Architectures.bdw, "bdw", "Broadwell"),
               new ArchitectureData(Architectures.slt, "slt", "Saltwell"),
               new ArchitectureData(Architectures.slm, "slm", "Silvermont"),
               new ArchitectureData(Architectures.glm, "glm", "Goldmont"),
               new ArchitectureData(Architectures.glp, "glp", "Goldmont Plus"),
               new ArchitectureData(Architectures.tnt, "tnt", "Tremont"),
               new ArchitectureData(Architectures.snr, "snr", "Snow Ridge"),
               new ArchitectureData(Architectures.skl, "skl", "Skylake"),
               new ArchitectureData(Architectures.cnl, "cnl", "Cannon Lake"),
               new ArchitectureData(Architectures.icl, "icl", "Ice Lake"),
               new ArchitectureData(Architectures.skx, "skx", "Skylake server"),
               new ArchitectureData(Architectures.clx, "clx", "Cascade Lake"),
               new ArchitectureData(Architectures.cpx, "cpx", "Cooper Lake"),
               new ArchitectureData(Architectures.icx, "icx", "Ice Lake server"),
               new ArchitectureData(Architectures.knl, "knl", "Knights landing"),
               new ArchitectureData(Architectures.knm, "knm", "Knights mill"),
               new ArchitectureData(Architectures.tgl, "tgl", "Tiger Lake"),
               new ArchitectureData(Architectures.adl, "adl", "Alder Lake"),
               new ArchitectureData(Architectures.spr, "spr", "Sapphire Rapids"),
               new ArchitectureData(Architectures.future, "future", "Future chip"),
            };
        }

        public string ArchitectureEnumToLongName(Architectures a)
        {
            foreach (ArchitectureData data in ArchitecturesTable)
            {
                if (data.arch == a)
                {
                    return data.longname;
                }
            }

            return null;
        }

        public string ArchitectureEnumToString(Architectures a)
        {
            foreach (ArchitectureData data in ArchitecturesTable)
            {
                if (data.arch == a)
                {
                    return data.archstr;
                }
            }

            return null;
        }

        public Architectures ArchitectureStringToEnum(string a)
        {
            foreach (ArchitectureData data in ArchitecturesTable)
            {
                if (data.longname == a || data.archstr == a)
                {
                    return data.arch;
                }
            }

            return Architectures.empty;
        }


        public Architectures Arch { get => arch; }
        public string Archstr { get => archstr; }
        public string Longname { get => longname; }
    }
}
