import { ReactElement } from "react";

export default interface ButtonProps {
  children: ReactElement | string;
  onClick: () => void;
}
