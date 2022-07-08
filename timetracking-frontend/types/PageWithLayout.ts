import { NextPage } from "next";
import { ReactElement, ReactNode } from "react";

type PageWithLayout = NextPage & {
  getLayout?: (page: ReactElement) => ReactElement;
};

export default PageWithLayout;
