import { useState } from "react";


export default function useQueryParam(loc: Location){
    const [location, setLocation] = useState(loc);

    const getQueryParam = <T extends unknown> (paramName: string): T | undefined => {
        const urlParams = new URLSearchParams(location.search);

        return urlParams.get(paramName) as T;
    }

    return {getQueryParam};
}