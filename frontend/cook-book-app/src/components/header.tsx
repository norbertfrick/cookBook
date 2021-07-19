import { useState } from "react";
import React from "react";

export default function Header() {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <nav>
        <div className="justify-around shadow-md max-w-5xl flex mx-auto bg-pink-400">
          <div className="flex space-x-16">
            <button>
              Recipes
            </button>
            <p>Navigation</p>
          </div>
          <p>logo</p>
          <div className="flex space-x-16">
            <p>Navigation</p>
            <p>Navigation</p>
          </div>
        </div>
      </nav>
    </div>
  );
}
