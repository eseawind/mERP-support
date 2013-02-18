# -*- coding: UTF-8 -*-
import clr
clr.AddReference("Feng.Windows")
from Feng.Utils import SecutiryHelper;

SecutiryHelper.SaveConnectionStrings(r"Hd.Run\connectionStrings.config", r"Reference\Data\Dbs.dat")




