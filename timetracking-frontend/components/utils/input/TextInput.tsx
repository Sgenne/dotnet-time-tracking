import { ChangeEventHandler } from "react";
import { getInputChangeHandler } from "../../../utils/adapters/InputElementChangeAdapter";
import TextInputProps from "../../../types/InputProps";
import StandardStyles from "../../../styles/utils/input/TextInput.module.css";

export type GenericTextInputProps = TextInputProps & {
  styles: { [key: string]: string };
  hidden?: boolean
};

const TextInput = ({ onChange, value, styles, hidden = false }: GenericTextInputProps) => {
  const changeHandler: ChangeEventHandler<HTMLInputElement> =
    getInputChangeHandler(onChange);

  const inputType = hidden ? "password" : "default";

  return (
    <div className={`${StandardStyles["input-container"]} ${styles["input-container"]}`}>
      <input type={inputType} value={value} onChange={changeHandler} />
    </div>
  );
};

export default TextInput;
