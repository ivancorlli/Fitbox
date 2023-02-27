import React from "react";
import SettingsPage from "./SettingsPage";

export default function Layout({children}:{children:React.ReactNode})
{
    return(
        <SettingsPage>
            {children}
        </SettingsPage>
    )
}