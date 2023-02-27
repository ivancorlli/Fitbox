'use client'

import { Button } from "@chakra-ui/react"
import { MouseEventHandler, ReactElement } from "react"


export default function SocialButton({
color,
border,
bg,
icon,
children,
hover,
onClick
}:{
hover?:Object
children:React.ReactNode,
color:string,
border:string,
bg:string,
icon:ReactElement,
onClick:MouseEventHandler
})
{
    return (
        <>
            <Button
                        color={color} 
                        border={border} 
                        bg={bg}
                        w='320px' 
                        // maxW='350px'
                        rightIcon={icon} 
                        _hover={hover}
                        onClick={onClick}
                        >
                            {children}
                        </Button>
        
        </>
    )
}