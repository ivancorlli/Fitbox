import InfoNavbar from "@/components/navbar/InfoNavbar"
import { Show, VStack } from "@chakra-ui/react"
import React from "react"


function GeneralLayout({children,name}:{children:React.ReactNode,name:string}) {

    return (
        <>
            <VStack align='start' spacing={5}>
                <Show below="md">
                    <InfoNavbar back={true} name={name} px="10px" />
                </Show>
                <Show above="md">
                    <InfoNavbar back={false} name={name} px="10px" />
                </Show>
                <VStack w='100%' align='start'>
                    {children}
                </VStack>
            </VStack>

        </>
    )
}
export default GeneralLayout