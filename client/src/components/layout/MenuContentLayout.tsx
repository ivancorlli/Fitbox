'use client'

import { Show } from "@chakra-ui/react"
import MobileNavbar from "../navbar/MobileNavbar"
import BaseContentLayout from "./BaseContentLayout"

interface PageProps {
    children: React.ReactNode
}

export default function MenuContentLayout(
    props: PageProps

) {
    return (
        <>
            <BaseContentLayout>
                <Show below="sm">

                    <MobileNavbar icon={false} />
                </Show>
                {props.children}
            </BaseContentLayout>
        </>
    )
}