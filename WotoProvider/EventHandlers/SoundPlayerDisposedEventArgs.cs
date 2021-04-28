﻿// WotoProvider (for LTW)
// Copyright (C) 2019 - 2021 wotoTeam, TeaInside
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace WotoProvider.EventHandlers
{
    public class SoundPlayerDisposedEventArgs : WotoEventArgs
    {
        public SoundPlayerDisposedEventArgs(WotoCreation wotoCreation) :
            base(wotoCreation)
        {

        }
    }
}
